using MediatR;

namespace MasterData.Application.Commands;

public class CreateCountryCommand : IRequest<Guid>
{
    public string IsoCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}