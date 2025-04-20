using Blog.Domain.Models;
using FluentValidation;

namespace Blog.Core.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Text is required.")
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Text cannot be just whitespace.");

            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Reference to Post cannot be empty.");
        }
    }
}
