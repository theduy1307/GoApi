using GoSolution.Entity.Entities;

namespace MasterData.Core.Repositories;

public interface IAccountRepository : IAsyncRepository<Account>
{
    Task<Account> GetByEmailAsync(string email);
}