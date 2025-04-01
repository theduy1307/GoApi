using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace MasterData.Api.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next, IServiceProvider provider)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // regex match request file. ex: abc/index.html, abc/def/image.png
            if (!Regex.IsMatch(context.Request.Path.Value, @"(\.[^\\]+)$"))
            {
                context.Response.OnStarting(state =>
                {
                    var httpContext = (HttpContext)state;
                    if (!httpContext.Response.Headers.ContainsKey("Content-Type"))
                    {
                        httpContext.Response.Headers.Add("Content-Type", new[] { "application/json" });
                    }
                    return Task.CompletedTask;
                }, context);


                using (var newBody = new MemoryStream())
                {
                    var originalBody = context.Response.Body;
                    context.Response.Body = newBody;

                    string error = "";
                    try
                    {
                        await next(context);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    // 304: not modify không cho phép ghi dữ liệu vào response
                    if (context.Response.StatusCode != 304)
                    {
                        // đọc response body, với các status code # 200 mà do hệ thống ném ra exception thì response body = "", 
                        // ghi mới response body theo chuẩn.
                        newBody.Position = 0;
                        var newContent = await new StreamReader(newBody).ReadToEndAsync();

                        MemoryStream updatedStream = new MemoryStream();
                        if (newContent == "")
                        {
                            updatedStream = GenerateStreamFromStatusCode(context.Response.StatusCode, "");
                        }
                        else
                        {
                            // tạo lại stream từ body ban đầu, nếu không thì response sẽ bị rỗng 
                            updatedStream = GenerateStreamFromString(newContent);
                        }
                        if (error != "")
                        {
                            updatedStream = GenerateStreamFromStatusCode(500, error);
                            context.Response.StatusCode = 500;
                        }

                        updatedStream.Position = 0;
                        await updatedStream.CopyToAsync(originalBody);

                        context.Response.Body = originalBody;
                    }
                    else
                    {
                        context.Response.Body = originalBody;
                    }
                }
            }
            else
            {
                await next(context);
            }

        }

        private static MemoryStream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static MemoryStream GenerateStreamFromStatusCode(int status, string pMessage)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            string messageCode = "";
            switch (status)
            {
                case 400: messageCode = "BadRequest"; break;
                case 401: messageCode = "Unauthorized"; break;
                case 403: messageCode = "Forbidden"; break;
                case 404: messageCode = "NotFound"; break;
                case 405: messageCode = "MethodNotAlowed"; break;
                case 409: messageCode = "Conflict"; break;
                case 500: messageCode = "InternalServerError"; break;
                case 501: messageCode = "NotImplemented"; break;
                default: messageCode = "InternalServerError"; break;
            }
            string message = pMessage == "" ? messageCode : pMessage;
            var result = JsonConvert.SerializeObject(new { isSuccess = false, isError = true, error = new {code = status, message = message} });
            writer.Write(result);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
}