using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Get reviews list
        /// </summary>
        /// <returns>Reviews list</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDTO>))]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> Get()
            => Ok(await _reviewService.GetAll());

        /// <summary>
        /// Add new Review
        /// </summary>
        /// <param name="reviewPostDTO">data of new review</param>
        /// <returns>Review id created from database</returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReviewPostDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(ReviewPostDTO reviewPostDTO)
        {
            int id = await _reviewService.CreateNewAsync(reviewPostDTO);
            return Created($"{HttpContext.Request.Path}/{id}", $"new review with id= [{id}] added");
        }

        /// <summary>
        /// Change data in exiting review
        /// </summary>
        /// <param name="reviewPutDTO">Data fresh data</param>
        /// <returns>Review id updated from database</returns>
        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(ReviewPutDTO reviewPutDTO)
            => Ok($"The changes have passed successfully on actor ID=[{await _reviewService.PutAsync(reviewPutDTO)}]");

        /// <summary>
        /// Delete review
        /// </summary>
        /// <param name="reviewId">Review id to delete</param>
        /// <returns>Review id removed from Database</returns>
        [HttpDelete]
        [Route("{reviewId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int reviewId)
            => Ok($"Review was removed on ID=[{await _reviewService.DeleteReviewAsync(reviewId)}]");
    }
}
