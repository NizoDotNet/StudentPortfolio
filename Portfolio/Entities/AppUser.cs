using Microsoft.AspNetCore.Identity;

namespace Portfolio.Entities;

public class AppUser : IdentityUser
{
    public ICollection<Class> Classes { get; set; }
    public ICollection<LabWork> LabWorks { get; set; }
}
