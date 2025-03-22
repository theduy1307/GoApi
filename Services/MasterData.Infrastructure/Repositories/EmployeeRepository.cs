using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MasterData.Infrastructure.Repositories;

public class EmployeeRepository(PoseidonDbContext context) : RepositoryBase<Employee>(context), IEmployeeRepository
{
    public async Task<Employee> GetEmployeeById(Guid employeeId)
    {
        return await context.Employees
            .Include(x => x.Roles)
            .Include(x => x.Account)
            .FirstAsync(x => x.Id == employeeId);
    }
}