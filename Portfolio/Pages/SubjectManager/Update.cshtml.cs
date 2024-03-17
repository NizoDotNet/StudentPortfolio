using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Models.Subject;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

[ModelStateFilter]
public class UpdateModel(IRepository<Subject> _subjectRepository,
    IMapper _mapper) : PageModel
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

}
