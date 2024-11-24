using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MasterData.Infrastructure.Repositories;

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(PoseidonDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Country>> GetCountryByName(string countryName)
    {
        var countryLists = await _context.Countries.ToListAsync();
        var countryList = await _context.Countries.Where(x => x.Name.ToLower().Contains(countryName)).ToListAsync();
        return countryList;
    }
}