using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;
using Portfolio.Filter;
using Portfolio.Models.Class;
using Portfolio.Repository;

namespace Portfolio.Pages.ClassManager;

[ModelStateFilter]
public class CreateModel(IRepository<Class> _classRepository,
    IMapper _mapper,
    IRepository<Subject> _subjectRepository,
    UserManager<AppUser> _userManager) : PageModel
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
        var users = await _userManager.Users.ToListAsync();

        SubjectsList = new(subs, nameof(Subject.Id), nameof(Subject.Name));
        UsersList = new(users, nameof(AppUser.Id), nameof(AppUser.UserName));
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var cls = _mapper.Map<Class>(ClassVM);
        cls.Students = new List<AppUser>();
        cls.Subjects = new List<Subject>(); 
        await AddUsersToClassAsync(cls);
        await AddSubjectsToClassAsync(cls);
        await _classRepository.CreateAsync(cls);
        return RedirectToPage("Index");
    }

    private async Task AddUsersToClassAsync(Class cls)
    {
        for (int i = 0; i < UsersIds.Count; i++)
        {
            var user = await _userManager.FindByIdAsync(UsersIds[i]);
            cls.Students.Add(user);
        }
    }

    private async Task AddSubjectsToClassAsync(Class cls)
    {
        for(int i = 0; i < SubjectIds.Count;i++)
        {
            var sub = await _subjectRepository.GetAsync(SubjectIds[i]);
            cls.Subjects.Add(sub);
        }
    }


}