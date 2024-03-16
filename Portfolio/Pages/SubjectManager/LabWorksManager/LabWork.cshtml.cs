using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.LabWork;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager.LabWorksManager;

public class LabWorkModel(IRepository<LabWork> labRepository, IMapper mapper) : PageModel
{
    private readonly IRepository<LabWork> _labRepository = labRepository;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public LabWorkViewModel LabWorkVM { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var lab = await _labRepository.GetAsync(id);
        if(lab == null) return NotFound();
        LabWorkVM = _mapper.Map<LabWorkViewModel>(lab);
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        await _labRepository.Delete(LabWorkVM.Id);
        return RedirectToPage("Index");
    }
}
