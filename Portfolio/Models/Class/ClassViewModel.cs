﻿using Portfolio.Entities;
using Portfolio.Models.Subject;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Class;

public class ClassViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public IList<AppUser> Students { get; set; }
    public IList<SubjectViewModel> Subjects { get; set; }
}
