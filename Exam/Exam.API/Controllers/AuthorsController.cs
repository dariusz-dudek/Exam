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

        /// <summary>
        /// Change data in existing actor
        /// </summary>
        /// <param name="authorPutDTO">Data fresh data</param>
        /// <returns>ActorId updated from DataBase</returns>
        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(AuthorPutDTO authorPutDTO)
            => Ok($"The changes have passed successfully on actor ID=[{await _authorService.PutAsync(authorPutDTO)}]");

        /// <summary>
        /// Refresh all Actor data
        /// </summary>
        /// <param name="actorId">Id actor</param>
        /// <param name="actorData">Fresh data</param>
        /// <returns>ActorId updated from DataBase</returns>
        [HttpPatch]
        [Route("{actorId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PATCH(int actorId, AuthorPatchDTO actorData)
            => Ok($"The changes have passed successfully on actor ID=[{await _authorService.UpdateAuthorAsync(actorId, actorData)}]");

        [HttpDelete]
        [Route("{actorId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int actorId)
            => Ok($"Actor was removed on ID=[{await _authorService.DeleteAuthorAsync(actorId)}]");
    }
}
