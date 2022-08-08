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

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(AuthorDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Create(AuthorPostDTO authorPostDTO)
        {
            int id = await _authorService.CreateNewAsync(authorPostDTO);
            return Created($"{HttpContext.Request.Path}/{id}", $"New Author with id = [{id}] added");
        }
    }
}
