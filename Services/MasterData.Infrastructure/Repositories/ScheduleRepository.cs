using GoSolution.Entity;
using GoSolution.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using MasterData.Core.Repositories;

namespace MasterData.Infrastructure.Repositories;

public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
{
    public ScheduleRepository(PoseidonDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Schedule>> GetCountryByName(string scheduleName)
    {
        return await _context.Schedules.Where(x => x.Name.ToLower().Contains(scheduleName)).ToListAsync();
    }
}