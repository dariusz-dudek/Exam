namespace Exam.Data.DAL.Interfaces
{
    public interface IMaterialTypesRepository : IRepository<MaterialType>
    {
        Task<MaterialType> GetByIdAsync(int materialId);
    }
}