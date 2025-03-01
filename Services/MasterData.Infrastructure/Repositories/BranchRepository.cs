using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;

namespace MasterData.Infrastructure.Repositories;

public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
{
    public BranchRepository(PoseidonDbContext context) : base(context)
    {
    }
}