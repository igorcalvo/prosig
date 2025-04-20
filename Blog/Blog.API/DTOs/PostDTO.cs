namespace Blog.API.DTOs
{
    public class PostDTO
    {
        public Guid? Id { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public List<CommentDTO> Comments { get; set; } = new();
    }
}
