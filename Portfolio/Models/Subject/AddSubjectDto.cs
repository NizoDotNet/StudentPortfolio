using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Subject;

public class AddSubjectDto
{
    [Required, Length(3, 30)]
    public string Name { get; set; }
}
