using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Models
{
    public class Comment : BaseModel
    {
        [Required]
        public required string Text { get; set; }


        public Guid PostId { get; set; }

        public required virtual Post Post { get; set; }
    }
}
