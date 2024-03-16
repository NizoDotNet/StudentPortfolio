using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Models.Subject;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

[ModelStateFilter]
public class UpdateModel(IRepository<Subject> subjectRepository, IMapper mapper) : PageModel
{
    private readonly IRepository<Subject> _subjectRepository = subjectRepository;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public SubjectViewModel SubjectVM { get; set; }
    public Subject Subject { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Subject = await _subjectRepository.GetAsync(id);
        if (Subject == null)
            return NotFound();
        SubjectVM = _mapper.Map<SubjectViewModel>(Subject);
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var sub = _mapper.Map<Subject>(SubjectVM);
        await _subjectRepository.UpdateAsync(sub.Id, sub);
        return RedirectToPage("Index");
    }
}
