namespace Exam.API.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMaterialTypesRepository _materialTypesRepository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper, IAuthorRepository authorRepository, IMaterialTypesRepository materialTypesRepository)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _materialTypesRepository = materialTypesRepository;
        }

        public async Task<int> CreateNewAsync(MaterialPostDTO materialPostDTO)
        {
            var material = _mapper.Map<Material>(materialPostDTO);
            _materialRepository.Create(material);
            var author = await _authorRepository.GetByIdAsync(material.AuthorId);
            var materialTypes = await _materialTypesRepository.GetByIdAsync(material.MaterialTypeId);
            if (materialTypes == null)
            {
                throw new ResourceNotFoundException($"There isn't material type by id {material.MaterialTypeId}");
            }
            if (author == null)
            {
                throw new ResourceNotFoundException($"There isn't author by id {material.AuthorId}");
            }
            _authorRepository.IncreasingCounter(material.AuthorId);
            await _materialRepository.SaveChangesAsync();
            return material.Id;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllAsync()
        {
            var materials = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialDTO>>(materials);
        }
    }
}
