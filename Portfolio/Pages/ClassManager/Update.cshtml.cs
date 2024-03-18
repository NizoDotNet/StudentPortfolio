using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.Class;
using Portfolio.Repository;

namespace Portfolio.Pages.ClassManager;

public class UpdateModel(IClassRepository _classRepository,
    IMapper _mapper,
    ILogger<UpdateModel> _logger) : PageModel
{
    [BindProperty]
    public ClassViewModel ClassVM { get; set; }
    [BindProperty]
    public SubjectCheck[] SubjectChecks { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var cls = await _classRepository.GetAsync(id);
        if(cls == null) return NotFound();
        ClassVM = _mapper.Map<ClassViewModel>(cls);
        SubjectChecks = new SubjectCheck[ClassVM.Subjects.Count+1];
        return Page();
    }

    public async Task OnPostAsync()
    {
        foreach (var item in SubjectChecks)
        {
            _logger.LogInformation("{ID} {Checked}", item.subId, item.checkedSub);
        }
    }
}


public record SubjectCheck(int subId, bool checkedSub);
