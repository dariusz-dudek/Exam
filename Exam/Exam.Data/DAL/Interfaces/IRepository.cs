namespace Exam.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Delete(T entity);

        Task<bool> SaveChangesAsync();

        void Update(T entity);
    }
}