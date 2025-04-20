using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Models
{
    public class Comment : BaseModel
    {
        [Required]
        public required string Text { get; set; }


        public Guid BlogPostId { get; set; }

        public required virtual BlogPost BlogPost { get; set; }
    }
}
