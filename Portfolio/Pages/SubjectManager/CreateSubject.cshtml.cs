using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Models.Subject;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

[ModelStateFilter]
public class CreateSubjectModel(IRepository<Subject> subjectRepository, IMapper mapper) : PageModel
{
    private readonly IRepository<Subject> _subjectRepository = subjectRepository;
    private readonly IMapper _mapper = mapper;
    [BindProperty]
    public AddSubjectViewModel SubjectVM { get; set; }

    public async Task OnGetAsync()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Subject subject = _mapper.Map<Subject>(SubjectVM);
        await _subjectRepository.CreateAsync(subject);
        return RedirectToPage("Index");
    }
}
