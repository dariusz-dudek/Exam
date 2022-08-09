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

        /// <summary>
        /// Get all materials by material type
        /// </summary>
        /// <param name="materialTypeId">Material type id</param>
        /// <returns>List of materials by material type</returns>
        [HttpGet]
        [Route("{materialTypeId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetByMaterialTypeId(int materialTypeId)
            => Ok(await _materialService.GetByMaterialTypeIdAsync(materialTypeId));

        /// <summary>
        /// Add new Material
        /// </summary>
        /// <param name="materialPostDTO">Date of the new material</param>
        /// <returns>MaterialId created from database</returns>
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

        /// <summary>
        /// Refresh material data
        /// </summary>
        /// <param name="materialId">Material id</param>
        /// <param name="materialPatchDTO">Fresh data</param>
        /// <returns>Material id updated from database</returns>
        [HttpPatch]
        [Route("{materialId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Patch(int materialId, MaterialPatchDTO materialPatchDTO)
            => Ok($"The changes have passed successfully on material ID=[{await _materialService.UpdateMaterialAsync(materialId, materialPatchDTO)}]");

        /// <summary>
        /// Delete material
        /// </summary>
        /// <param name="materialId">Material id to delete</param>
        /// <returns>Material id removed form database</returns>
        [HttpDelete]
        [Route("{materialId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int materialId)
            => Ok($"Actor was removed on ID=[{await _materialService.DeleteMaterialAsync(materialId)}]");

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(MaterialPutDTO materialPutDTO)
            => Ok($"The changes have passed successfully on material ID=[{await _materialService.PutAsync(materialPutDTO)}]");
    }
}
