using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// Get Material list
        /// </summary>
        /// <returns>Material list</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialDTO>))]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> Get()
            => Ok(await _materialService.GetAllAsync());

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(MaterialDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Post(MaterialPostDTO materialPostDTO)
        {
            int id = await _materialService.CreateNewAsync(materialPostDTO);
            return Created($"{HttpContext.Request.Path}/{id}", $"new Material with id= [{id}] added.");
        }
    }
}
