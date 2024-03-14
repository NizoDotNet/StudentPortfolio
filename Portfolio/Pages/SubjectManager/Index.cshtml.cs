using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

public class IndexModel : PageModel
{
    private readonly IRepository<Subject> _subjectRepository;

    public IndexModel(IRepository<Subject> subjectRepository)
    {
        this._subjectRepository = subjectRepository;
    }

    [BindProperty]
    public IEnumerable<Subject> Subjects { get; set; }
    public async Task OnGet()
    {
        Subjects = await _subjectRepository.GetAllAsync();
    }
}
