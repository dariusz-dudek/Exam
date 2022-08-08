namespace Exam.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<bool> IsExistByNameAsync(string name);
    }
}