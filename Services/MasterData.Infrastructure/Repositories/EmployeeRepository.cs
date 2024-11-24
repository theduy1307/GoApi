using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;

namespace MasterData.Infrastructure.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(PoseidonDbContext context) : base(context)
    {
    }
}