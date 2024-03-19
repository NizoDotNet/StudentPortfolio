using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NuGet.Packaging;
using Portfolio.Entities;
using Portfolio.Repository;

namespace Portfolio.Helper;

public class AddToCollection
{
    public async Task Add<T>(ICollection<T> collection, IRepository<T> repository, List<int> ids)
    {
        for (var i = 0; i < ids.Count; i++)
        {
            var entity = await repository.GetAsync(ids[i]);
            collection.Add(entity);
        }
    }
    public async Task AddUsersToClassAsync(Class cls, List<string> UsersIds, UserManager<AppUser> _userManager)
    {
        var users = await _userManager
            .Users
            .Where(c => UsersIds.Contains(c.Id))
            .ToListAsync();

        cls.Students.AddRange(users);
    }
}
