﻿using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.Entities.MovieModels;

public class MovieRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
}
