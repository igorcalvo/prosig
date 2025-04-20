using Blog.Core.Validators;
using Blog.Domain.Models;
using FluentValidation.TestHelper;

namespace Blog.Test.Validators
{
    public  class PostValidatorTests
    {
        private PostValidator _postValidator;

        [SetUp]
        public void Setup()
        {
            _postValidator = new PostValidator();
        }

        [Test]
        public void PostValidator_Should_Have_Error_When_Title_Is_Whitespace()
        {
            var post = new Post { Title = "   ", Content = "Content" };
            var result = _postValidator.TestValidate(post);
            result.ShouldHaveValidationErrorFor(p => p.Title);
        }

        [Test]
        public void PostValidator_Should_Have_Error_When_Content_Is_Null()
        {
            var post = new Post { Title = "Title", Content = null! };
            var result = _postValidator.TestValidate(post);
            result.ShouldHaveValidationErrorFor(p => p.Content);
        }
    }
}
