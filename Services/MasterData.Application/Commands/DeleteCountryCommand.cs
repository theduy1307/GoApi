using MediatR;

namespace MasterData.Application.Commands;

public class DeleteCountryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}