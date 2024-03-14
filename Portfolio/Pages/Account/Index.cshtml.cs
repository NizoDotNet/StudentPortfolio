using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Portfolio.Pages.Account;

[Authorize]
public class IndexModel : PageModel
{

    [BindProperty]
    public List<Claim> Claim { get; set; }
    public void OnGet()
    {
        Claim = User.FindAll("Role").ToList();

    }
}
