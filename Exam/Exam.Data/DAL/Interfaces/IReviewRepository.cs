namespace Exam.Data.DAL.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllAsync();

        Task<Review> GetByIdAsync(int reviewId);
    }
}