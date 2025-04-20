using Blog.Core.Validators;
using Blog.Domain.Models;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Test.Validators
{
    public  class CommentValidatorTests
    {
        private CommentValidator _commentValidator;
        private Post _post;

        [SetUp]
        public void Setup()
        {
            _commentValidator = new CommentValidator();
            _post = new Post { Title = "Post Title", Content = "Post Content" };
        }

        [Test]
        public void CommentValidator_Should_Have_Error_When_Text_Is_Empty()
        {
            
            var comment = new Comment(){ Text = "", Id = Guid.NewGuid(), Post = _post };
            var result = _commentValidator.TestValidate(comment);
            result.ShouldHaveValidationErrorFor(c => c.Text);
        }

        [Test]
        public void CommentValidator_Should_Have_Error_When_Id_Is_Empty()
        {
            var comment = new Comment(){ Text = "Valid", Id = Guid.Empty, Post = _post };
            var result = _commentValidator.TestValidate(comment);
            result.ShouldHaveValidationErrorFor(c => c.Id);
        }
    }
}
