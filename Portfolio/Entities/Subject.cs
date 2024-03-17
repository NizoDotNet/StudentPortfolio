using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class Subject
{
    [Key]

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public IList<Class> Classes { get; set; } 

    public string TeacherId { get; set; }
    public AppUser Teacher { get; set; }
}
