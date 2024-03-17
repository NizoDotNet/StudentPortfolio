using Microsoft.AspNetCore.Identity;

namespace Portfolio.Entities;

public class AppUser : IdentityUser
{
    public IList<Class> Classes { get; set; }
    public IList<LabWork> LabWorks { get; set; }
}
