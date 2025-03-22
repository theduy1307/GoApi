using System.Net.Http.Headers;
using System.Text.Json;
using MasterData.Core.Shared;
using Microsoft.AspNetCore.Http;

namespace MasterData.Application.Services;

public interface IJobsGoService
{
    Task<JobsGoResponse> GetCvInformation(IFormFile file);
}
public class JobsGoService(HttpClient httpClient) : IJobsGoService
{
    public async Task<JobsGoResponse> GetCvInformation(IFormFile file)
    {
        using var formData = new MultipartFormDataContent();
        if (file.Length > 0)
        {
            var fileStream = file.OpenReadStream();
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            formData.Add(streamContent, "file", file.FileName);
        }

        // 📤 Gửi request đến API
        var jobsGoResponse = await httpClient.PostAsync($"https://api.jobsgo.vn/parse-cv", formData);
        if (jobsGoResponse.IsSuccessStatusCode)
        {
            var jsonData = await jobsGoResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<JobsGoResponse>(jsonData) ?? new JobsGoResponse();
            return response;
        }
        return new JobsGoResponse();
    }
}