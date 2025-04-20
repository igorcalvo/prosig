using Blog.Domain.Models;

namespace Blog.Core.Interfaces
{
    public interface IPostService
    {
        public Task<Guid> Create(Post post);

        public Task<int> AddComment(Guid id, Comment comment);
    }
}
