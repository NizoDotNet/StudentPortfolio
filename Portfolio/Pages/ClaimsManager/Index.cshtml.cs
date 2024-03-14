using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;

namespace Portfolio.Pages.ClaimsManager;

public class IndexModel : PageModel
{
    public UserManager<AppUser> UserManager { get; set; }
    public IndexModel(UserManager<AppUser> userManager)
    {
        UserManager = userManager;
    }
    public List<AppUser> Users { get; set; }
    public async Task OnGetAsync()
    {
        Users = await UserManager.Users.ToListAsync();
    }
}
