using Portfolio.Entities;
using Portfolio.Models.Class;
using Portfolio.Models.LabWork;

namespace Portfolio.Models.Subject;

public class SubjectDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IList<LabWorkDto> LabWorks { get; set; } = [];
    public IList<ClassDto> Classes { get; set; } = [];

    public AppUser Teacher { get; set; }
}
