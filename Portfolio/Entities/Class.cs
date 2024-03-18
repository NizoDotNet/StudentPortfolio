using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class Class
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<AppUser> Students { get; set; } = [];
    public ICollection<Subject> Subjects { get; set; } = [];
}
