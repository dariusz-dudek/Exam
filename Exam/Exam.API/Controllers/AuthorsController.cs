namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Get authors list
        /// </summary>
        /// <returns>Actor list</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorDTO>))]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAll()
            => Ok(await _authorService.GetAll());


    }
}
