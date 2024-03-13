namespace Portfolio.Repository;

public interface IRepository<T>
{
    T Get(int id);
}
