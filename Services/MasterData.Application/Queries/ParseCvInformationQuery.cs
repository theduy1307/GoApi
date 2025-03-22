using MasterData.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MasterData.Application.Queries;

public class ParseCvInformationQuery : IRequest<CandidateDto>
{
    public IFormFile CvFile { get; set; }
}