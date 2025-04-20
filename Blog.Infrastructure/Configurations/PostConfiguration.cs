using Blog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasMany(b => b.Comments)
                   .WithOne(c => c.Post)
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
