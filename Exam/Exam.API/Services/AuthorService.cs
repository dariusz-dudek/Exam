
namespace Exam.API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAll()
        {
            var authors = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
        }

        public async Task<int> CreateNewAsync(AuthorPostDTO authorPostDTO)
        {
            if (await IsExistByNameAsync(authorPostDTO.Name))
            {
                throw new RecordAlreadyExistException($"Author with name {authorPostDTO.Name} already exist");
            }
            var author = _mapper.Map<Author>(authorPostDTO);
            _repository.Create(author);
            await _repository.SaveChangesAsync();
            return author.Id;
        }

        public async Task<bool> IsExistByNameAsync(string name)
            => await _repository.IsExistByNameAsync(name);
    }
}
