using MediatR;
using Microsoft.AspNetCore.Http;

namespace MasterData.Application.Queries;

public class ImportCertificateQuery : IRequest<List<string>>
{
    public List<IFormFile> CvFile { get; set; }
}
