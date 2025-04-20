using Blog.Core.Interfaces;
using Blog.Domain.Models;
using Blog.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public void CreateNew(Post post)
        {

        }
    }
}
