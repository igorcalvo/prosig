using Blog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasMany(b => b.Comments)
                   .WithOne(c => c.BlogPost)
                   .HasForeignKey(c => c.BlogPostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
