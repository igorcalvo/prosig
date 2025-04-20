using Blog.Core.Interfaces;
using Blog.Domain.Models;
using Blog.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Blog.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;

        public PostService(ILogger<PostService> logger, ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _logger = logger;
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        public async Task<int> AddComment(Guid id, Comment comment)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null) throw new ArgumentOutOfRangeException($"Couldn't find post with id: {id}");

            post.Comments.Add(comment);
            await _postRepository.UpdateAsync(post);

            return post.Comments.Count();
        }

        public async Task<Guid> Create(Post post)
        {
            if (post.Id != Guid.Empty) throw new ArgumentOutOfRangeException("Post must be created with an empty Id");

            await _postRepository.AddAsync(post);
            return post.Id;
        }
    }
}
