using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.Class;
using Portfolio.Repository;

namespace Portfolio.Pages.ClassManager;

public class ClassModel(IRepository<Class> _classRepository, IMapper _mapper) : PageModel
{
    [BindProperty]
    public ClassViewModel ClassVM { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var cls = await _classRepository.GetAsync(id);
        if (cls == null) return NotFound();
        ClassVM = _mapper.Map<ClassViewModel>(cls);
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        await _classRepository.Delete(ClassVM.Id);
        return RedirectToPage("Index");
    }
}
