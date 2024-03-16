using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.Class;
using Portfolio.Repository;

namespace Portfolio.Pages.ClassManager;

public class CreateModel(IRepository<Class> _classRepository,
    IMapper _mapper,
    IRepository<Subject> _subjectRepository) : PageModel
{
    [BindProperty]
    public ClassViewModel ClassVM { get; set; }
    public async Task OnGetAsync()
    {

    }
}
