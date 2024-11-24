using GoSolution.Entity;
using MasterData.Core.Repositories;
using MasterData.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasterData.Infrastructure.Extensions;

public static class InfraServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<PoseidonDbContext>();
        serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        serviceCollection.AddScoped<ICountryRepository, CountryRepository>();
        serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return serviceCollection;
    }
}