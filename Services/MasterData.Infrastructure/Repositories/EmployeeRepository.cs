using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MasterData.Infrastructure.Repositories;

public class EmployeeRepository(PoseidonDbContext context) : RepositoryBase<Employee>(context), IEmployeeRepository
{
}