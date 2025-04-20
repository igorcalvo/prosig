using Blog.Domain.Models;
using FluentValidation;

namespace Blog.Core.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Title cannot be just whitespace.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Content cannot be just whitespace.");
        }
    }
}
