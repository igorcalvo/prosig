using AutoMapper;

namespace Blog.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Mapping error occurred");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { error = "Internal mapping error." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { error = "Something went wrong." });
            }
        }
    }
}
