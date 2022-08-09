namespace Exam.Data.DAL.Repositories
{
    public class MaterialTypesRepository : Repository<MaterialType>, IMaterialTypesRepository
    {
        public MaterialTypesRepository(ExamContext context) : base(context)
        {
        }

        public async Task<MaterialType> GetByIdAsync(int materialId)
            => await Context
            .MaterialTypes
            .FirstOrDefaultAsync(m => m.MaterialTypeId == materialId);
    }
}