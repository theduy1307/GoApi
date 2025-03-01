using AutoMapper;
using MediatR;
using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MasterData.Core.Repositories;

namespace MasterData.Application.Handlers;

public class GetEmployeeSchedulingByDateQueryHandler : IRequestHandler<GetEmployeeSchedulingByDateQuery, List<EmployeeScheduleDto>>
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IMapper _mapper;

    public GetEmployeeSchedulingByDateQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }
    public async Task<List<EmployeeScheduleDto>> Handle(GetEmployeeSchedulingByDateQuery request, CancellationToken cancellationToken)
    {
        var schedules =
            await _scheduleRepository.GetAllAsync(x =>x.EmployeeSchedules.Any(c => c.Date == request.Date && c.EmployeeId == request.EmployeeId));
        var employeeSchedules = schedules.SelectMany(x => x.EmployeeSchedules);
        return _mapper.Map<List<EmployeeScheduleDto>>(employeeSchedules);
    }
}