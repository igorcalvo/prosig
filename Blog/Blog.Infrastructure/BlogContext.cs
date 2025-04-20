using Blog.Domain.Models;
using Blog.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure
{
    public class BlogContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
        public DbSet<Comment> Comments => Set<Comment>();

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogPostConfiguration());
        }
    }
}
