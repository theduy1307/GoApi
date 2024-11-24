using MediatR;

namespace MasterData.Application.Commands;

public class UpdateCountryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string IsoCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}