using Portfolio.Entities;

namespace Portfolio.Repository;

public interface IClassRepository : IRepository<Class>
{
    Task RemoveSubjectsRangeAsync(Class cls, IList<int> ids);

}
