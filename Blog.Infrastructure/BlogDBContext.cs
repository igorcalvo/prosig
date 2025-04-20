using Blog.Domain.Models;
using Blog.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure
{
    public class BlogDBContext : DbContext
    {
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();

        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }
    }
}
