using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class Subject
{
    [Key]

    public int Id { get; set; }

    [StringLength(25)]
    public string Name { get; set; }

    public IList<LabWork> LabWorks { get; set; }
    public IList<Class> Classes { get; set; }

    public string TeacherId { get; set; }
    public AppUser Teacher { get; set; }
}
