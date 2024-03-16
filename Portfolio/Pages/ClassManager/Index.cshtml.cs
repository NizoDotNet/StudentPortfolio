using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.Class;
using Portfolio.Repository;

namespace Portfolio.Pages.ClassManager;

public class IndexModel(IRepository<Class> _classRepository,
    IMapper _mapper) : PageModel
{

    public IEnumerable<ClassViewModel> Classes { get; set; }
    public async Task OnGetAsync()
    {
        var cls = await _classRepository.GetAllAsync();
        Classes = _mapper.Map<IEnumerable<ClassViewModel>>(cls);
    }
}
