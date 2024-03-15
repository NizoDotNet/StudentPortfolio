﻿using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.LabWork;

public class AddLabWorkDto
{
    [MinLength(3)]
    public string Name { get; set; }
    public bool Completed { get; set; } = false;
    public int SubjectId { get; set; }
}
