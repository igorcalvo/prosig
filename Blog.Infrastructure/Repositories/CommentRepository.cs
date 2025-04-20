using Blog.Domain.Models;
using Blog.Infrastructure.Interfaces;

namespace Blog.Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly BlogDBContext _context;

        public CommentRepository(BlogDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
