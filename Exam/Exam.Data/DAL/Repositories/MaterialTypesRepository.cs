namespace Exam.Data.DAL.Repositories
{
    public class MaterialTypesRepository : Repository<MaterialType>, IMaterialTypesRepository
    {
        public MaterialTypesRepository(ExamContext context) : base(context)
        {
        }
    }
}