using Blog.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ILogger<CommentsController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] CommentDTO comment)
        {
            throw new NotImplementedException();
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] CommentDTO comment)
        {
            throw new NotImplementedException();
            return Ok();
        }
    }
}
