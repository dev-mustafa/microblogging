
namespace MicroBlog.Domain.Validations;

using FluentValidation;
using Dtos;

public class CreatePostValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostValidator(IValidator<ImageDto> imageValidator)
    {
        RuleFor(p => p.Content)
            .NotEmpty().WithMessage("Post text is required.")
            .MaximumLength(140).WithMessage("Post text cannot exceed 140 characters.");

        RuleFor(p => p.Image)
            .SetValidator(imageValidator!)
            .When(p => p.Image is not null);
    }
}
