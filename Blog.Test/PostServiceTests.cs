using Blog.Core.Services;
using Blog.Domain.Models;
using Blog.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Blog.Test
{
    public class PostServiceTests
    {

        [Test]
        public void Create_Should_Throw_If_Id_Is_Not_Empty()
        {
            var loggerMock = new Mock<ILogger<PostService>>();
            var postRepoMock = new Mock<IPostRepository>();
            var commentRepoMock = new Mock<ICommentRepository>();

            var service = new PostService(loggerMock.Object, commentRepoMock.Object, postRepoMock.Object);

            var post = new Post { Id = Guid.NewGuid(), Title = "Title", Content = "Content" };

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.Create(post));
        }
    }
}
