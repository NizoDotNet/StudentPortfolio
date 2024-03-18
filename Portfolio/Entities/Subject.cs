using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class Subject
{
    [Key]

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public ICollection<Class> Classes { get; set; } 

}
