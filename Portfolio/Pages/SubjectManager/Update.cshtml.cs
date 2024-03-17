using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Models.Subject;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

[ModelStateFilter]
public class UpdateModel(IRepository<Subject> _subjectRepository, 
    IMapper _mapper,
    IRepository<LabWork> _labRepositroy,
    ILogger<UpdateModel> _logger) : PageModel
{

    [BindProperty]
    public SubjectViewModel SubjectVM { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var subject = await _subjectRepository.GetAsync(id);
        if (subject == null) return NotFound();

        SubjectVM = _mapper.Map<SubjectViewModel>(subject);
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var sub = _mapper.Map<Subject>(SubjectVM);
        await _subjectRepository.UpdateAsync(sub.Id, sub);
        return RedirectToPage("Index");
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        for (int i = 0; i < SubjectVM.LabWorks.Count; i++)
        {
            _logger.LogInformation("{LabWorkId} {LabName}", 
                SubjectVM.LabWorks[i].Id, SubjectVM.LabWorks[i].Name);
        }
        return Page();
    }
}
