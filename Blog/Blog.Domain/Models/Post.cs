using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Models
{
    public  class Post : BaseModel
    {
        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        public virtual List<Comment> Comments { get; set; } = new();
    }
}
