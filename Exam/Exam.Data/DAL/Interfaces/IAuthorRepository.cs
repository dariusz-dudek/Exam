namespace Exam.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<bool> IsExistByNameAsync(string name);
        Task<Author> GetByIdAsync(int authorId);
        void IncreasingCounter(int authorId);
        void DecreasingCounter(int authorId);
    }
}