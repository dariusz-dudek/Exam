namespace Exam.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllReadOnlyAsync();
    }
}