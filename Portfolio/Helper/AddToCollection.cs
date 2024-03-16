using Portfolio.Repository;

namespace Portfolio.Helper;

public class AddToCollection
{
    public async Task Add<T>(IList<T> collection, IRepository<T> repository, List<int> ids)
    {
        for (var i = 0; i < ids.Count; i++)
        {
            var entity = await repository.GetAsync(ids[i]);
            collection.Add(entity);
        }
    }
}
