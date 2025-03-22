using GoSolution.Entity.Entities;

namespace MasterData.Core.Repositories;

public interface IEmployeeRepository : IAsyncRepository<Employee>
{
    Task<Employee> GetEmployeeById(Guid employeeId);
}