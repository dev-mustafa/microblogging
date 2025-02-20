using System.ComponentModel.DataAnnotations;

namespace MicroBlog.Domain.Entities;

public class Image
{
    public Guid Id { get; set; }
    [Required]
    [Url(ErrorMessage = "Invalid image URL.")]
    public string Url { get; set; }
    public Guid PostId { get; set; }

    public Post Post { get; set; }
}