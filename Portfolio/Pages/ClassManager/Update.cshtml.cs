using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Entities;
using Portfolio.Helper;
using Portfolio.Models.Class;
using Portfolio.Repository;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Portfolio.Pages.ClassManager;

public class UpdateModel(IClassRepository _classRepository,
    IRepository<Subject> _subjectRepository,
    UserManager<AppUser> _userManager,
    AddToCollection _helper,
    IMapper _mapper) : PageModel
{
    [BindProperty]
    public ClassViewModel ClassVM { get; set; }
    [BindProperty]
    public List<SubjectCheck> SubjectChecks { get; set; }
    [BindProperty]
    public List<int> SubjectIds { get; set; }
    [BindProperty]
    public List<string> UsersIds { get; set; }
    public SelectList SubjectsList { get; set; }
    public SelectList UsersList { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var cls = await _classRepository.GetAsync(id);
        if(cls == null) return NotFound();
        ClassVM = _mapper.Map<ClassViewModel>(cls);

        await GetOptions(cls);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var subjectsToRemove = SubjectChecks
            .Where(c => !c.checkedSub)
            .Select(c => c.subId)
            .ToList();

        var cls = await _classRepository.GetAsync(ClassVM.Id);
        await _helper.Add(cls.Subjects, _subjectRepository, SubjectIds);

        await _classRepository.RemoveCollectionRangeAsync(cls, subjectsToRemove);
        return RedirectToPage("Class", new { id = ClassVM.Id});
    }

    private async Task GetOptions(Class cls)
    {
        var subs = await _subjectRepository.GetAllAsync();
        var users = await _userManager.GetUsersForClaimAsync(new("Role", "Student"));

        SubjectsList = new(subs, nameof(Subject.Id), nameof(Subject.Name));
        UsersList = new(users, nameof(AppUser.Id), nameof(AppUser.UserName));
    }
}


public record SubjectCheck(int subId, bool checkedSub);
