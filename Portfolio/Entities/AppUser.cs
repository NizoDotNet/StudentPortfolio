using Microsoft.AspNetCore.Identity;

namespace Portfolio.Entities;

public class AppUser : IdentityUser
{
    public IList<Subject> Subjects { get; set; }
}
