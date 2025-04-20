using Blog.Core.Interfaces;
using Blog.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Blog.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ILogger<CommentService> _logger;
        private readonly ICommentRepository _commentRepository;

        public CommentService(ILogger<CommentService> logger, ICommentRepository commentRepository)
        {
            _logger = logger;
            _commentRepository = commentRepository;
        }
    }
}
