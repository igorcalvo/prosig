using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
