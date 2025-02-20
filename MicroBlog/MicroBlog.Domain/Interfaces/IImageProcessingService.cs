namespace MicroBlog.Domain.Interfaces;

public interface IImageProcessingService
{
    Task<byte[]> ConvertToWebPAsync(byte[] imageData);
    Task<Dictionary<string, byte[]>> ResizeImageAsync(byte[] imageData);
}