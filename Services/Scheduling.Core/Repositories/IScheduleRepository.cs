using GoSolution.Entity.Entities;

namespace Scheduling.Core.Repositories;

public interface IScheduleRepository : IAsyncRepository<Schedule>
{
    Task<IEnumerable<Schedule>> GetCountryByName(string scheduleName);
}