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
    public SubjectDto Subject { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var sub = await _subjectRepository.GetAsync(id);
        if (sub == null) return NotFound();
        Subject = _mapper.Map<SubjectDto>(sub);    
        return Page();
    }
}
