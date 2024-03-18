using Portfolio.Entities;

namespace Portfolio.Repository;

public interface IClassRepository : IRepository<Class>
{
    Task RemoveSubjectRange(IList<int> ids);
}
