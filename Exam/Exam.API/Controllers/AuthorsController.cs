namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repository;

        public AuthorsController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _repository.GetAllReadOnlyAsync();
        }
    }
}
