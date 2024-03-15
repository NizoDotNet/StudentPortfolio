using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class Class
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(30)]
    public string Name { get; set; }
    public IList<AppUser> Students { get; set; } = [];
    public IList<Subject> Subjects { get; set; } = [];
}
