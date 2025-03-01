using MediatR;
using Microsoft.Extensions.Logging;
using MasterData.Application.Commands;
using MasterData.Core.Repositories;

namespace MasterData.Application.Handlers;

public class UpdateEmployeeSchedulingCommandHandler : IRequestHandler<UpdateEmployeeSchedulingCommand, Guid[]>
{
    private IScheduleRepository _scheduleRepository;
    private readonly ILogger<UpdateEmployeeSchedulingCommandHandler> _logger;

    public UpdateEmployeeSchedulingCommandHandler(IScheduleRepository scheduleRepository, ILogger<UpdateEmployeeSchedulingCommandHandler> logger)
    {
        _scheduleRepository = scheduleRepository;
        _logger = logger;
    }
    public Task<Guid[]> Handle(UpdateEmployeeSchedulingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}