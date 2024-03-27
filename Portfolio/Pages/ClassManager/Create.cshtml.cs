using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Helper;
using Portfolio.Models.Class;
using Portfolio.Repository;

namespace Portfolio.Pages.ClassManager;

[ModelStateFilter]
public class CreateModel(IRepository<Class> _classRepository,
    IMapper _mapper,
    IRepository<Subject> _subjectRepository,
    UserManager<AppUser> _userManager,
    AddToCollection _helper) : PageModel
{
    [BindProperty]
    public ClassViewModel ClassVM { get; set; }
    [BindProperty]
    public List<int> SubjectIds { get; set; }
    [BindProperty]
    public List<string> UsersIds { get; set; }
    public SelectList SubjectsList { get; set; }
    public SelectList UsersList { get; set; }
    public async Task OnGetAsync()
    {
        var subs = await _subjectRepository.GetAllAsync();
        var users = await _userManager.GetUsersForClaimAsync(new("Role", "Student"));

        SubjectsList = new(subs, nameof(Subject.Id), nameof(Subject.Name));
        UsersList = new(users, nameof(AppUser.Id), nameof(AppUser.UserName));
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var cls = _mapper.Map<Class>(ClassVM);
        cls.Students = new List<AppUser>();
        cls.Subjects = new List<Subject>(); 
        await _helper.AddUsersToClassAsync(cls, UsersIds, _userManager);
        await _helper.AddAsync(cls.Subjects, _subjectRepository, SubjectIds);
        await _classRepository.CreateAsync(cls);
        return RedirectToPage("Index");
    }

    



}
