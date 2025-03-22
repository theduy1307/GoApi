using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;
using MasterData.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MasterData.Infrastructure.Repositories;

public class RecruitmentCampaignRepository: RepositoryBase<RecruitmentCampaign>, IRecruitmentCampaignRepository
{
    public RecruitmentCampaignRepository(PoseidonDbContext context) : base(context)
    {
    }
}