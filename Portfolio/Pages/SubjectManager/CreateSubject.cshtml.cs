using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.Subject;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

public class CreateSubjectModel(IRepository<Subject> subjectRepository, IMapper mapper) : PageModel
{
    private readonly IRepository<Subject> _subjectRepository = subjectRepository;
    private readonly IMapper _mapper = mapper;
    [BindProperty]
    public AddSubjectDto SubjectDto { get; set; }

    public async Task OnGetAsync()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Subject subject = _mapper.Map<Subject>(SubjectDto);
        await _subjectRepository.CreateAsync(subject);
        return RedirectToPage("Index");
    }
}