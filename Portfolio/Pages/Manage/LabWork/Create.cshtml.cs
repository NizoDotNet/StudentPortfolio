using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Filter;
using Portfolio.Models.LabWork;
using Portfolio.Repository;

namespace Portfolio.Pages.Manage.LabWork;

[ModelStateFilter]
public class Create(IRepository<Entities.LabWork> _labRepository,
    IMapper _mapper) : PageModel
{

    [BindProperty]
    public AddLabWorkViewModel LabWorkVM { get; set; }
    public async Task OnGetAsync()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var lab = _mapper.Map<Entities.LabWork>(LabWorkVM);
        await _labRepository.CreateAsync(lab);
        return Redirect("Index");
    }
}
