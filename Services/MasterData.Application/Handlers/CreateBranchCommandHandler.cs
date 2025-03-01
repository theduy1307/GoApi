using AutoMapper;
using GoSolution.Entity.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using MasterData.Application.Commands;
using MasterData.Application.Responses;
using MasterData.Core.Repositories;

namespace MasterData.Application.Handlers;

public class CreateBranchCommandHandler(IBranchRepository branchRepository, IMapper mapper, ILogger<CreateBranchCommandHandler> logger)
    : IRequestHandler<CreateBranchCommand, BranchResponse>
{
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<CreateBranchCommandHandler> _logger = logger;
    public async Task<BranchResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branchEntity = _mapper.Map<Branch>(request);
        branchEntity.Id = Guid.NewGuid();
        branchEntity.CreateDate = DateTime.UtcNow;
        var result = await _branchRepository.AddAsync(branchEntity);
        logger.LogInformation($"Schedule with Id {result.Id} successfully created");
        return _mapper.Map<BranchResponse>(result);
    }
}