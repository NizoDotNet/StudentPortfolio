using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Models.LabWork;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager.LabWorksManager;

[ModelStateFilter]
public class CreateLabWorkModel : PageModel
{
    private readonly IRepository<LabWork> _labRepository;
    private readonly IMapper _mapper;

    public CreateLabWorkModel(IRepository<LabWork> labRepository, IMapper mapper)
    {
        _labRepository = labRepository;
        _mapper = mapper;
    }

    [BindProperty]
    public AddLabWorkDto LabWorkDto { get; set; }
    public async Task OnGetAsync()
    {

    }

    public async Task OnPostAsync()
    {
        var lab = _mapper.Map<LabWork>(LabWorkDto);
        await _labRepository.CreateAsync(lab);
    }
}
