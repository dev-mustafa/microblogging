using FluentValidation;
using MicroBlog.Domain.Dtos;

namespace MicroBlog.Domain.Validations;

public class ImageValidator : AbstractValidator<ImageDto>
{
    private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png", ".webp"];
    private const int MaxFileSizeInBytes = 2 * 1024 * 1024; // 2MB

    public ImageValidator()
    {
        RuleFor(x => x.FileData)
            .NotNull().WithMessage("Image file is required.")
            .Must(IsValidFileSize).WithMessage("File size must be under 2MB.");

        RuleFor(x => x.OriginalFileName)
            .NotEmpty().WithMessage("Image must have a filename.")
            .Must(IsValidFileType).WithMessage("Only JPG, PNG, and WebP formats are allowed.");
    }

    private static bool IsValidFileType(string? fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return false;
        var extension = Path.GetExtension(fileName).ToLower();
        return Array.Exists(AllowedExtensions, ext => ext == extension);
    }

    private static bool IsValidFileSize(byte[]? fileData)
    {
        return fileData != null && fileData.Length <= MaxFileSizeInBytes;
    }
}