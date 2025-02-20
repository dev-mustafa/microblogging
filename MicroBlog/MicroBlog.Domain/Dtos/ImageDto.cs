namespace MicroBlog.Domain.Dtos;

public record ImageDto
{
    public byte[]? FileData { get; set; }
    public string? OriginalFileName { get; set; }
    public string Url { get; set; }
}