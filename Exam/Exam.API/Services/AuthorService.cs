
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
                throw new RecordAlreadyExistException($"Author with name {authorPostDTO.Name} already exist");
            var author = _mapper.Map<Author>(authorPostDTO);
            _repository.Create(author);
            await _repository.SaveChangesAsync();
            return author.Id;
        }

        public async Task<bool> IsExistByNameAsync(string name)
            => await _repository.IsExistByNameAsync(name);

        public async Task<int> PutAsync(AuthorPutDTO authorPutDTO)
        {
            var author = await _repository.GetById(authorPutDTO.Id);
            if (author == null)
                throw new ResourceNotFoundException("Author not found");
            author.Name = authorPutDTO.Name;
            author.Password = authorPutDTO.Password;
            author.Role = authorPutDTO.Role;
            await _repository.SaveChangesAsync();
            return author.Id;
        }

        public async Task<int> UpdateAuthorAsync(int authorId, AuthorPatchDTO authorPatchDTO)
        {
            if (authorPatchDTO.Name == null)
                throw new ResourceNotFoundException("Author not found");
            var author = await _repository.GetById(authorId);
            if (authorPatchDTO.Name != null)
                author.Name = authorPatchDTO.Name;
            if (authorPatchDTO.Password != null)
                author.Password = authorPatchDTO.Password;
            if (authorPatchDTO.Role != null)
                author.Role = authorPatchDTO.Role;
            _repository.Update(author);
            await _repository.SaveChangesAsync();
            return author.Id;
        }

        public async Task<int> DeleteAuthorAsync(int authorId)
        {
            var actor = await _repository.GetById(authorId);
            if (actor == null)
                throw new ResourceNotFoundException($"Not Found actor with id: {authorId}");
            _repository.Delete(actor);
            await _repository.SaveChangesAsync();
            return authorId;
        }
    }
}
