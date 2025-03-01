using MediatR;
using MasterData.Application.Responses;

namespace MasterData.Application.Commands;

public class CreateBranchCommand : IRequest<BranchResponse>
{
    public string Name { get; set; }
}