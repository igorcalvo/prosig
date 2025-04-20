using AutoMapper;
using Blog.API.DTOs;
using Blog.Core.Interfaces;
using Blog.Domain.Models;
using Blog.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    public class PostsController : BaseController
    {
        private readonly ILogger<PostsController> _logger;
        private readonly IPostService _postService;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostsController(
            ILogger<PostsController> logger,
            IPostService postService,
            IPostRepository postRepository,
            IMapper mapper
            )
        {
            _logger = logger;
            _postService = postService;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postRepository.GetAllAsync();
            var dtos = _mapper.Map<List<PostDTO>>(posts);

            return Ok(dtos);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] PostDTO post)
        {
            var postModel = _mapper.Map<Post>(post);
            var id = await _postService.Create(postModel);

            return Ok(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("id is Required");

            var post = await _postRepository.GetByIdAsync(id);
            if (post == null) return NotFound();

            var dto = _mapper.Map<PostDTO>(post);
            return Ok(dto);
        }

        [HttpPost]
        [Route("{id}/comments")]
        public async Task<IActionResult> Add(Guid id, [FromBody] CommentDTO comment)
        {
            if (id == Guid.Empty) return BadRequest("id is Required");
            comment.PostId = id;
            var commentModel = _mapper.Map<Comment>(comment);

            int commentCount = await _postService.AddComment(id, commentModel);
            return Ok(commentCount);

        }
    }
}
