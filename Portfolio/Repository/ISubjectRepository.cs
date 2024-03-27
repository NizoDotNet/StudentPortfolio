using Portfolio.Entities;
using System.Linq.Expressions;

namespace Portfolio.Repository;

public interface ISubjectRepository : IRepository<Subject>
{
    Task<List<Subject>> GetAsync(List<int> ids);   
}
