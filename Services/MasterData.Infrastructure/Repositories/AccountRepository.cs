using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MasterData.Infrastructure.Repositories;

public class AccountRepository(PoseidonDbContext context) : RepositoryBase<Account>(context), IAccountRepository
{
    public async Task<Account> GetByEmailAsync(string email)
    {
        return await context.Accounts.FirstOrDefaultAsync(x => x.Username == email);
    }
}