using Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    public class PostsController : BaseController
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
            return Ok();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create()
        {
            throw new NotImplementedException();
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            throw new NotImplementedException();
            return Ok();
        }

        [HttpPost]
        [Route("{id}/comments")]
        public async Task<IActionResult> GetById(Guid id, [FromBody] Comment comment)
        {
            throw new NotImplementedException();
            return Ok();
        }
    }
}
