namespace MicroBlog.Domain.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Post
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(140, ErrorMessage = "Post content cannot exceed 140 characters.")]
    public required string Content { get; set; }

    public string UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    [Required]
    [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90 degrees.")]
    public double Latitude { get; set; }

    [Required]
    [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180 degrees.")]
    public double Longitude { get; set; }

    public User User { get; set; }

    public ICollection<Image> Images { get; set; } = new List<Image>();

    public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

}
