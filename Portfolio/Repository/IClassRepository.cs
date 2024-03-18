using Portfolio.Entities;

namespace Portfolio.Repository;

public interface IClassRepository : IRepository<Class>
{
    Task RemoveCollectionRangeAsync(Class cls, IList<int> ids);
}
