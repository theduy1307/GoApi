using GoSolution.Entity.Entities;

namespace MasterData.Core.Repositories;

public interface IMenuRepository : IAsyncRepository<Menu>
{
    Task<IReadOnlyList<Menu>> GetMenuByRolesId(List<Guid> rolesId);
}