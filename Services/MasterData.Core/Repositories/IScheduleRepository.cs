using GoSolution.Entity.Entities;

namespace MasterData.Core.Repositories;

public interface IScheduleRepository : IAsyncRepository<Schedule>
{
    Task<IEnumerable<Schedule>> GetCountryByName(string scheduleName);
}