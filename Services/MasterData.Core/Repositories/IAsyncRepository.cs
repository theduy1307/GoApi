using System.Linq.Expressions;
using GoSolution.Entity.Entities;

namespace MasterData.Core.Repositories;

public interface IAsyncRepository<T>
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetPagingAsync(int pageIndex, int pageSize);
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> CountAsync();
}