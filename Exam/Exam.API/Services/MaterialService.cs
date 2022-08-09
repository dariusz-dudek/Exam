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

        public async Task<int> DeleteMaterialAsync(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            if (material == null)
                throw new ResourceNotFoundException("Material not found");
            _materialRepository.Delete(material);
            _authorRepository.DecreasingCounter(material.AuthorId);
            await _materialRepository.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllAsync()
        {
            var materials = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialDTO>>(materials);
        }

        public async Task<IEnumerable<MaterialDTO>> GetByAuthorIdAndReviewAboveAsync(int authorId, int above)
        {
            var materials = await _materialRepository.GetByAuthorIdAndReviewAboveAsync(authorId, above);
            if (materials == null)
                throw new ResourceNotFoundException("Materials not found");
            return _mapper.Map<IEnumerable<MaterialDTO>>(materials);
        }

        public async Task<IEnumerable<MaterialDTO>> GetByMaterialTypeIdAsync(int materialTypeId)
        {
            if (await _materialTypesRepository.GetByIdAsync(materialTypeId) == null)
                throw new ResourceNotFoundException("Material type not found");
            var materials = await _materialRepository.GetByMaterialTypeIdAsync(materialTypeId);
            if (materials == null)
                throw new ResourceNotFoundException("Materials not found");
            return _mapper.Map<IEnumerable<MaterialDTO>>(materials);
        }

        public async Task<int> PutAsync(MaterialPutDTO materialPutDTO)
        {
            var material = await _materialRepository.GetByIdAsync(materialPutDTO.Id);

            if (material == null)
                throw new ResourceNotFoundException("Material not found.");
            material.Location = materialPutDTO.Location;

            if (await _authorRepository.GetByIdAsync(materialPutDTO.AuthorId) == null)
                throw new ResourceNotFoundException("Author not found.");
            material.AuthorId = materialPutDTO.AuthorId;
            _authorRepository.DecreasingCounter(material.AuthorId);
            _authorRepository.IncreasingCounter(materialPutDTO.AuthorId);

            material.Description = materialPutDTO.Description;

            material.Title = materialPutDTO.Title;

            if (await _materialTypesRepository.GetByIdAsync(materialPutDTO.MaterialTypeId) == null)
                throw new ResourceNotFoundException("Material type not found.");
            material.MaterialTypeId = materialPutDTO.MaterialTypeId;

            await _materialTypesRepository.SaveChangesAsync();
            return material.Id;
        }

        public async Task<int> UpdateMaterialAsync(int materialId, MaterialPatchDTO materialPatchDTO)
        {
            var material = await _materialRepository.GetByIdAsync(materialId);

            if (materialPatchDTO.Title != null)
                material.Title = materialPatchDTO.Title;

            if (materialPatchDTO.AuthorId != null && await _authorRepository.GetByIdAsync(materialPatchDTO.AuthorId.Value) != null)
            {
                _authorRepository.DecreasingCounter(material.AuthorId);
                _authorRepository.IncreasingCounter(materialPatchDTO.AuthorId.Value);
                material.AuthorId = materialPatchDTO.AuthorId.Value;
            }
            else if (materialPatchDTO.AuthorId == null)
            {
            }
            else
            {
                throw new ResourceNotFoundException("Author not found");
            }

            if (materialPatchDTO.Location != null)
                material.Location = materialPatchDTO.Location;

            if (materialPatchDTO.MaterialTypeId != null && await _materialTypesRepository.GetByIdAsync(materialPatchDTO.MaterialTypeId.Value) != null)
            {
                material.MaterialTypeId = materialPatchDTO.MaterialTypeId.Value;
            }
            else if (materialPatchDTO.MaterialTypeId == null)
            {
            }
            else
            {
                throw new ResourceNotFoundException("Material type not found");
            }

            if (materialPatchDTO.Description != null)
                material.Description = materialPatchDTO.Description;

            _materialRepository.Update(material);
            await _materialRepository.SaveChangesAsync();
            return material.Id;
        }
    }
}