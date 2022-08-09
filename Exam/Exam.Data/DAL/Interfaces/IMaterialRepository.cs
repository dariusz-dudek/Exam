namespace Exam.Data.DAL.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<IEnumerable<Material>> GetAllAsync();
    }
}