using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using MasterData.Application.Dtos;
using MasterData.Application.Responses;

namespace MasterData.Application.Handlers;

public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, ScheduleResponse>
{
    private readonly IMapper _mapper;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly ILogger<CreateBranchCommandHandler> _logger;

    public CreateScheduleCommandHandler(IMapper mapper, IScheduleRepository scheduleRepository, ILogger<CreateBranchCommandHandler> logger)
    {
        _mapper = mapper;
        _scheduleRepository = scheduleRepository;
        _logger = logger;
    }
    public async Task<ScheduleResponse> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var scheduleEntity = _mapper.Map<Schedule>(request);
        scheduleEntity.Id = Guid.NewGuid();
        var generatorCountry = await _scheduleRepository.AddAsync(scheduleEntity);
        _logger.LogInformation($"Schedule with Id {generatorCountry.Id} successfully created");
        return _mapper.Map<ScheduleResponse>(generatorCountry);
    }
}