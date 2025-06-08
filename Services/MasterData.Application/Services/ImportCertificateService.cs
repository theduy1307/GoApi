using Microsoft.AspNetCore.Http;
using Google.Cloud.Vision.V1;
using Image = Google.Cloud.Vision.V1.Image;

namespace MasterData.Application.Services;

public interface IImportCertificateService
{
    Task<List<string>> GetInfoVisionApi(List<IFormFile> lstFile);
}
public class ImportCertificateService(HttpClient httpClient) : IImportCertificateService
{
    public async Task<List<string>> GetInfoVisionApi(List<IFormFile> lstFile)
    {
        // Path to service account key JSON file MasterData.Api/Properties
        const string jsonPath = "./Properties/causal-rite-387802-4e37b5913fde.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", jsonPath);

        // Create a client
        var client = await ImageAnnotatorClient.CreateAsync();
        var result = new List<string>();
        // Perform label detection
        var lstImage = ConvertIFormFileToImage(lstFile);
        foreach (var img in lstImage)
        {
            var res = await client.DetectTextAsync(img);
            for (var i = 1; i < res.Count; i++)
            {
                if (res[i].Description.Contains("score", StringComparison.CurrentCultureIgnoreCase)
                    && double.TryParse(res[i+1].Description, out double score))
                {
                    result.Add(res[i+1].Description);
                }
            }
        }
        
        return result;
    }
    
    private static List<Image> ConvertIFormFileToImage(List<IFormFile> lstFile)
    {
        var lstImg = new List<Image>();
        foreach (var file in lstFile)
        {
            using var stream = file.OpenReadStream();
            lstImg.Add(Image.FromStream(stream));
        }
        return lstImg;
    }
}