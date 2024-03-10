using Microsoft.AspNetCore.Identity;

namespace Portfolio.Entities;

public class AppUser : IdentityUser
{
    public IList<AppUser> Classes { get; set; }
    public IList<Subject> Subjects { get; set; }
    public AppUser? Teacher { get; set; }
    public string TeacherId { get; set; }
}
