using System.Text;
using GoSolution.Entity;
using MasterData.Application.Abtractions;
using MasterData.Core.Repositories;
using MasterData.Infrastructure.Authentication;
using MasterData.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MasterData.Infrastructure.Extensions;

public static class InfraServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<PoseidonDbContext>();
        serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        serviceCollection.AddScoped<IJwtProvider, JwtProvider>();
        serviceCollection.AddScoped<IPasswordProvider, PasswordProvider>();
        serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        serviceCollection.AddScoped<IBranchRepository, BranchRepository>();
        serviceCollection.AddScoped<IScheduleRepository, ScheduleRepository>();
        serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
        serviceCollection.AddScoped<IMenuRepository, MenuRepository>();
        serviceCollection.AddScoped<IRecruitmentCampaignRepository, RecruitmentCampaignRepository>();
        return serviceCollection;
    }
}