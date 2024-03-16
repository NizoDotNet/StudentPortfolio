using Portfolio.Entities;
using Portfolio.Models.Class;
using Portfolio.Models.LabWork;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Subject;

public class SubjectViewModel
{
    public int Id { get; set; }
    [Required, Length(3, 30)]
    public string Name { get; set; }

    public IList<LabWorkViewModel> LabWorks { get; set; } = [];
    public IList<ClassViewModel> Classes { get; set; } = [];

    public AppUser Teacher { get; set; }
}
