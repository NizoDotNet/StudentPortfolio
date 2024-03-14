﻿using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class Class
{
    [Key]

    public int Id { get; set; }
    public string Name { get; set; }
    public IList<AppUser> Students { get; set; }
}