using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.Subject;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

public class SubjectModel : PageModel
{
    private readonly IRepository<Subject> _subjectRepository;
    private readonly IMapper _mapper;

    public SubjectModel(IRepository<Subject> subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    [BindProperty]
    public SubjectDto SubjectDto { get; set; }
    public Subject Subject { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Subject = await _subjectRepository.GetAsync(id);
        if (Subject == null) return NotFound();
        SubjectDto = _mapper.Map<SubjectDto>(Subject);    
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        await _subjectRepository.Delete(SubjectDto.Id);
        return RedirectToPage("Index");
    }
}
