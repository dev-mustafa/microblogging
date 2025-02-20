namespace MicroBlog.Domain.Services;

using Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading.Tasks;

public class ImageProcessingService : IImageProcessingService
{
    private readonly string[] _resizedDimensions = { "200x200", "500x500", "1000x1000" };

    public async Task<byte[]> ConvertToWebPAsync(byte[] imageData)
    {
        using var image = Image.Load(imageData);
        using var ms = new MemoryStream();
        await image.SaveAsWebpAsync(ms);
        return ms.ToArray();
    }

    public async Task<Dictionary<string, byte[]>> ResizeImageAsync(byte[] imageData)
    {
        var resizedImages = new Dictionary<string, byte[]>();

        foreach (var size in _resizedDimensions)
        {
            var dimensions = size.Split('x');
            int width = int.Parse(dimensions[0]);
            int height = int.Parse(dimensions[1]);

            using var image = Image.Load(imageData);
            image.Mutate(x => x.Resize(width, height));

            using var ms = new MemoryStream();
            await image.SaveAsWebpAsync(ms);
            resizedImages[size] = ms.ToArray();
        }

        return resizedImages;
    }
}