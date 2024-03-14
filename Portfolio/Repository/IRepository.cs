namespace Portfolio.Repository;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(int id);
    Task Delete(int id);
    Task UpdateAsync(int id, T entity);
    Task CreateAsync(T entity);
}
