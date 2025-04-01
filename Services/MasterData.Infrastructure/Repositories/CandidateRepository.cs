using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;

namespace MasterData.Infrastructure.Repositories;

public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
{
    public CandidateRepository(PoseidonDbContext context) : base(context)
    {
    }
}