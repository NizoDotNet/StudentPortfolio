﻿using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class LabWork
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public bool Completed { get; set; } = false;
    public IList<AppUser> Users { get; set; } = [];
}
