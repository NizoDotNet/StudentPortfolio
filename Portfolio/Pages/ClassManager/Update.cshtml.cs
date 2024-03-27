using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Claims;
using Portfolio.Entities;
using Portfolio.Helper;
using Portfolio.Models.Class;
using Portfolio.Models.Subject;
using Portfolio.Repository;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Portfolio.Pages.ClassManager;

public class UpdateModel(IClassRepository _classRepository,
    ISubjectRepository _subjectRepository,
    UserManager<AppUser> _userManager,
    AddToCollection _helper,
    IMapper _mapper) : PageModel
{
    [BindProperty]
    public ClassViewModel ClassVM { get; set; }
    [BindProperty]
    public List<Check<int>> SubjectChecks { get; set; }
    [BindProperty]
    public List<Check<string>> UserCheck { get; set; }
    [BindProperty]
    public List<SubjectViewModel> SubjectsVM { get; set; }
    [BindProperty]
    public IList<AppUser> Users { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var cls = await _classRepository.GetAsync(id);
        if (cls == null) return NotFound();
        ClassVM = _mapper.Map<ClassViewModel>(cls);
        Users = await _userManager.GetUsersForClaimAsync(new("Role", MyClaimValues.Student));
        var subjects = await _subjectRepository.GetAllAsync();
        SubjectsVM = _mapper.Map<List<SubjectViewModel>>(subjects);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var subjectsIds = SubjectChecks
            .Where(c => c.check)
            .Select(c => c.Id)
            .ToList();

        var usersIds = UserCheck
            .Where(c => c.check)
            .Select(c => c.Id)
            .ToList();

        var cls = await _classRepository.GetAsync(ClassVM.Id);
        var subs = await _subjectRepository.GetAsync(subjectsIds);
        
        var users = await _userManager
            .Users
            .Where(c => usersIds.Contains(c.Id))
            .ToListAsync();
        cls.Students = users;
        cls.Subjects = subs;
        await _classRepository.SaveChangesAsync();  


        return RedirectToPage("Class", new { id = cls.Id }); ;
    }

}


public record Check<T>(T Id, bool check);

