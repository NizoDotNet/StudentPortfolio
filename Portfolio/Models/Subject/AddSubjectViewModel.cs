using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Subject;

public class AddSubjectViewModel
{
    [Required, Length(3, 30)]
    public string Name { get; set; }
}
