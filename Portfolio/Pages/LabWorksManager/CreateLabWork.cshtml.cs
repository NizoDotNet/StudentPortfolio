using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Models.LabWork;
using Portfolio.Repository;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Pages.LabWorksManager;

[ModelStateFilter]
public class CreateLabWorkModel(IRepository<LabWork> labRepository,
    IRepository<Subject> subjectRepository,
    IMapper mapper) : PageModel
{
    private readonly IRepository<LabWork> _labRepository = labRepository;
    private readonly IRepository<Subject> _subjectRepository = subjectRepository;
    private readonly IMapper _mapper = mapper;

    public SelectList Subjects { get; set; }
    [BindProperty]
    public AddLabWorkViewModel LabWorkVM { get; set; }
    public async Task OnGetAsync()
    {
        var subs = await _subjectRepository.GetAllAsync();
        Subjects = new(subs, nameof(Subject.Id), nameof(Subject.Name));
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var lab = _mapper.Map<LabWork>(LabWorkVM);
        await _labRepository.CreateAsync(lab);
        return Redirect("Index");
    }
}
