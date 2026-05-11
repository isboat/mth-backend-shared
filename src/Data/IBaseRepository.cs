namespace MemeTokenHub.Shared.Data;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}
