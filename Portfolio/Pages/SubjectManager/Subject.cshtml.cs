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
    public SubjectViewModel SubjectVM { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var subject = await _subjectRepository.GetAsync(id);
        if (subject == null) return NotFound();
        SubjectVM = _mapper.Map<SubjectViewModel>(subject);    
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        await _subjectRepository.Delete(SubjectVM.Id);
        return RedirectToPage("Index");
    }
}
