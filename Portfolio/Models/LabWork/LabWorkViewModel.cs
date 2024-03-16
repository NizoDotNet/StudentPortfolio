using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.LabWork;

public class LabWorkViewModel
{
    public int Id { get; set; }
    [Required, MinLength(3)]
    public string Name { get; set; }
    public bool Completed { get; set; } = false;
}
