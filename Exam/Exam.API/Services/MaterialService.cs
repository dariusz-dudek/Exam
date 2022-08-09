namespace Exam.API.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllAsync()
        {
            var materials = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialDTO>>(materials);
        }
    }
}
