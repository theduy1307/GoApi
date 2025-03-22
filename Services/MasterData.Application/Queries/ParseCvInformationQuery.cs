using MasterData.Application.Dtos;
using MasterData.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MasterData.Application.Queries;

public class ParseCvInformationQuery : IRequest<JobsGoResponse>
{
    public IFormFile CvFile { get; set; }
}