namespace Portfolio.Repository;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(string id);
    Task Delete(string id);
    Task UpdateAsync(string id, T entity);
    Task CreateAsync(T entity);
}
