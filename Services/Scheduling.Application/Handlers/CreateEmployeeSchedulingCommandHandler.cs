using MediatR;
using Microsoft.Extensions.Logging;
using Scheduling.Application.Commands;
using Scheduling.Core.Repositories;

namespace Scheduling.Application.Handlers;

public class CreateEmployeeSchedulingCommandHandler
    : IRequestHandler<CreateEmployeeSchedulingCommand, Guid[]>
{
    private IScheduleRepository _scheduleRepository;
    private readonly ILogger<CreateEmployeeSchedulingCommandHandler> _logger;

    public CreateEmployeeSchedulingCommandHandler(IScheduleRepository scheduleRepository, ILogger<CreateEmployeeSchedulingCommandHandler> logger)
    {
        _scheduleRepository = scheduleRepository;
        _logger = logger;
    }
    public Task<Guid[]> Handle(CreateEmployeeSchedulingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}