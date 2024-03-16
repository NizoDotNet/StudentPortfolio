using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Helper;
using Portfolio.Models.Subject;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

[ModelStateFilter]
public class CreateSubjectModel(IRepository<Subject> subjectRepository, 
    IMapper mapper,
    IRepository<LabWork> _labRepository,
    AddToCollection _helper) : PageModel
{
    private readonly IRepository<Subject> _subjectRepository = subjectRepository;
    private readonly IMapper _mapper = mapper;
    [BindProperty]
    public AddSubjectViewModel SubjectVM { get; set; }
    [BindProperty]
    public List<int> LabWorkIds { get; set; }
    public SelectList LabList { get; set; }

    public async Task OnGetAsync()
    {
        var lab = await _labRepository.GetAllAsync();
        LabList = new(lab, nameof(LabWork.Id), nameof(LabWork.Name));
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Subject subject = _mapper.Map<Subject>(SubjectVM);
        subject.LabWorks = new List<LabWork>();
        await _helper.Add(subject.LabWorks, _labRepository, LabWorkIds);
        await _subjectRepository.CreateAsync(subject);
        return RedirectToPage("Index");
    }


}
