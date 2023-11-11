using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task GetByIdAsync(int id);
        Task CreateAsync (T entity);
        Task UpdateAsync (T entity);
        Task DeleteAsync (T entity);
    }
}
