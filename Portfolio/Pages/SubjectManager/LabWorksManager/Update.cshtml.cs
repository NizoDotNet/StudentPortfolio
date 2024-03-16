using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Models.LabWork;
using Portfolio.Repository;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Pages.SubjectManager.LabWorksManager;
[ModelStateFilter]
public class UpdateModel(IRepository<LabWork> labRepository,
    IMapper mapper,
    IRepository<Subject> subjectRepository) : PageModel
{
    private readonly IRepository<LabWork> _labRepository = labRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IRepository<Subject> _subjectRepository = subjectRepository;

    public SelectList Subjects { get; set; }
    [BindProperty]
    public UpdateLabWorkViewModel LabWorkVM { get; set; }
    [BindProperty, Required]
    public int SubjectId { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var lab = await _labRepository.GetAsync(id);
        if(lab == null) return NotFound();
        LabWorkVM = _mapper.Map<UpdateLabWorkViewModel>(lab);
        var subs = await _subjectRepository.GetAllAsync();
        Subjects = new(subs, nameof(Subject.Id), nameof(Subject.Name));
        return Page();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        LabWorkVM.SubjectId = SubjectId;
        var lab = _mapper.Map<LabWork>(LabWorkVM);
        await _labRepository.UpdateAsync(LabWorkVM.Id, lab);
        return RedirectToPage("Index");
    }
}
