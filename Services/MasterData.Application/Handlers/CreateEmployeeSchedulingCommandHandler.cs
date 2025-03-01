using MediatR;
using Microsoft.Extensions.Logging;
using MasterData.Application.Commands;
using MasterData.Core.Repositories;

namespace MasterData.Application.Handlers;

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