﻿using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class LabWork
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public bool Completed { get; set; } = false;
    public ICollection<AppUser> Users { get; set; } = [];
}
