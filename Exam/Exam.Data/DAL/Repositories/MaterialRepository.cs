namespace Exam.Data.DAL.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(ExamContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Material>> GetAllAsync()
            => await Context
            .Materials
            .ToListAsync();

        public async Task<Material> GetByIdAsync(int materialId)
            => await Context
            .Materials
            .FirstOrDefaultAsync(m => m.Id == materialId);

        public async Task<IEnumerable<Material>> GetByMaterialTypeIdAsync(int materialTypeId)
            => await Context
            .Materials
            .Where(m => m.MaterialTypeId == materialTypeId)
            .ToListAsync();
    }
}