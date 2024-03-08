using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class Subject
{
    public int Id { get; set; }

    [StringLength(25)]
    public string Name { get; set; }

    public IList<LabWork> LabWorks { get; set; }

    public string TeacherId { get; set; }
    public AppUser Teacher { get; set; }
}
