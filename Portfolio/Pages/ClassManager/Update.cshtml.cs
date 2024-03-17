using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.Class;
using Portfolio.Repository;

namespace Portfolio.Pages.ClassManager;

public class UpdateModel(IRepository<Class> _classRepository,
    IMapper _mapper) : PageModel
{
    
    public Class ClassVM { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        ClassVM = await _classRepository.GetAsync(id);
        if(ClassVM == null) return NotFound();

        return Page();
    }
}
