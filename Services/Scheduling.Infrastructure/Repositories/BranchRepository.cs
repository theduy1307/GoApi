using GoSolution.Entity;
using GoSolution.Entity.Entities;
using Scheduling.Core.Repositories;

namespace Scheduling.Infrastructure.Repositories;

public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
{
    public BranchRepository(PoseidonDbContext context) : base(context)
    {
    }
}