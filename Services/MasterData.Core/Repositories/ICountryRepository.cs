using GoSolution.Entity.Entities;

namespace MasterData.Core.Repositories;

public interface ICountryRepository : IAsyncRepository<Country>
{
    Task<IEnumerable<Country>> GetCountryByName(string countryName);
}