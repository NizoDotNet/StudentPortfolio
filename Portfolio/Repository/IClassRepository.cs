using Portfolio.Entities;

namespace Portfolio.Repository;

public interface IClassRepository : IRepository<Class>
{
    Task<Class> GetAsync(int id, bool includeCollections = true);
    Task RemoveSubjectsRangeAsync(Class cls, IList<int> ids);

}
