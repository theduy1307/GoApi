using AutoMapper;
using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MasterData.Application.Services;
using MediatR;

namespace MasterData.Application.Handlers.Queries;

public class ParseCvInformationQueryHandler(IJobsGoService jobsGoService, IMapper mapper) : IRequestHandler<ParseCvInformationQuery, CandidateDto>
{
    private readonly IJobsGoService _jobsGoService = jobsGoService;
    private readonly IMapper _mapper = mapper;

    public async Task<CandidateDto> Handle(ParseCvInformationQuery request, CancellationToken cancellationToken)
    {
        var response = await _jobsGoService.GetCvInformation(request.CvFile);
        return _mapper.Map<CandidateDto>(response);
    }
}