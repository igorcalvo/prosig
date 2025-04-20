namespace Blog.API.DTOs
{
    public class CommentDTO
    {
        public required string Text { get; set; }
        public Guid PostId { get; set; }
    }
}
