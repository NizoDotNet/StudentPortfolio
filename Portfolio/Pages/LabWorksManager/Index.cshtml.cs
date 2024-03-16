using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.LabWork;
using Portfolio.Repository;

namespace Portfolio.Pages.LabWorksManager;

public class IndexModel(IRepository<LabWork> labRepository, IMapper mapper) : PageModel
{
    private readonly IRepository<LabWork> _labRepository = labRepository;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public IEnumerable<LabWorkViewModel> LabWorkVM { get; set; }
    public async Task OnGetAsync()
    {
        var labs = await _labRepository.GetAllAsync();
        LabWorkVM = _mapper.Map<IEnumerable<LabWorkViewModel>>(labs);
    }
}
