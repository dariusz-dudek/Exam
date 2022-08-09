namespace Exam.Data.DAL.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<IEnumerable<Material>> GetAllAsync();
        Task<Material> GetByIdAsync(int materialId);
        Task<IEnumerable<Material>> GetByMaterialTypeIdAsync(int materialTypeId);
    }
}