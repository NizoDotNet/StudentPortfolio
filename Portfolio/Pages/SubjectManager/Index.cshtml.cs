using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities;
using Portfolio.Models.Subject;
using Portfolio.Repository;

namespace Portfolio.Pages.SubjectManager;

public class IndexModel : PageModel
{
    private readonly IRepository<Subject> _subjectRepository;
    private readonly IMapper _mapper;

    public IndexModel(IRepository<Subject> subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    [BindProperty]
    public IEnumerable<SubjectDto> Subjects { get; set; }
    public async Task OnGetAsync()
    {
        var subject = await _subjectRepository.GetAllAsync();
        Subjects = _mapper.Map<IEnumerable<SubjectDto>>(subject);    
    }
}
