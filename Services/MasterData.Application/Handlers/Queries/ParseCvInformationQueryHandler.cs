using AutoMapper;
using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MasterData.Application.Services;
using MasterData.Core.Shared;
using MediatR;

namespace MasterData.Application.Handlers.Queries;

public class ParseCvInformationQueryHandler(IJobsGoService jobsGoService, IMapper mapper) : IRequestHandler<ParseCvInformationQuery, JobsGoResponse>
{
    private readonly IJobsGoService _jobsGoService = jobsGoService;
    private readonly IMapper _mapper = mapper;

    public async Task<JobsGoResponse> Handle(ParseCvInformationQuery request, CancellationToken cancellationToken)
    {
        return await _jobsGoService.GetCvInformation(request.CvFile);
    }
}