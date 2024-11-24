using MediatR;
using Scheduling.Application.Responses;

namespace Scheduling.Application.Commands;

public class CreateBranchCommand : IRequest<BranchResponse>
{
    public string Name { get; set; }
}