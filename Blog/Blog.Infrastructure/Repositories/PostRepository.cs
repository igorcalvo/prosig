using Blog.Domain.Models;
using Blog.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly BlogDBContext _context;

        public PostRepository(BlogDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
