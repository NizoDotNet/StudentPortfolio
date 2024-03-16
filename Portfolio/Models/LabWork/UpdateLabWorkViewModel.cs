using Portfolio.Models.Subject;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.LabWork;

public class UpdateLabWorkViewModel
{
    public int Id { get; set; }
    [Required, MinLength(3)]
    public string Name { get; set; }
    public bool Completed { get; set; } = false;
    [Required]
    public int SubjectId { get; set; }
    public SubjectViewModel Subject { get; set; }

}
