namespace Blog.API.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ILogger<CommentsController> logger)
        {
            _logger = logger;
        }
    }
}
