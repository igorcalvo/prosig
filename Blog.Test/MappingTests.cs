using AutoMapper;
using Blog.API.DTOs;
using Blog.API.Mappings;
using Blog.Domain.Models;

namespace Blog.Test
{
    public class MappingTests
    {
        private IMapper _mapper;
        private Post _post;

        public MappingTests() 
        {
            _post = new Post { Title = "Post Title", Content = "Post Content" };
        }

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
                cfg.AddProfile<CommentProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Test]
        public void Should_Map_Comment_To_CommentDTO()
        {
            var comment = new Comment
            {
                Text = "Hello world",
                PostId = Guid.NewGuid(),
                Post = _post
            };

            var dto = _mapper.Map<CommentDTO>(comment);

            Assert.AreEqual(comment.Text, dto.Text);
            Assert.AreEqual(comment.PostId, dto.PostId);
        }

        [Test]
        public void Should_Map_Post_To_PostDTO()
        {
            var post = new Post
            {
                Title = "Title",
                Content = "Content",
                Comments = new List<Comment>
                {
                    new Comment { Text = "Comment", PostId = Guid.NewGuid(), Post = _post }
                }
            };

            var dto = _mapper.Map<PostDTO>(post);

            Assert.AreEqual(post.Title, dto.Title);
            Assert.AreEqual(post.Content, dto.Content);
            Assert.AreEqual(post.Comments.Count, dto.Comments.Count);
        }

        [Test]
        public void Should_Map_List_Of_Posts_To_DTOs()
        {
            var posts = new List<Post>
            {
                new Post { Title = "T1", Content = "C1" },
                new Post { Title = "T2", Content = "C2" }
            };

            var dtos = _mapper.Map<List<PostDTO>>(posts);

            Assert.AreEqual("T1", dtos[0].Title);
            Assert.AreEqual("C2", dtos[1].Content);
        }
    }
}
