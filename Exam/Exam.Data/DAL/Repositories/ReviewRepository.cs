namespace Exam.Data.DAL.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ExamContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
            => await Context
            .Reviews
            .ToListAsync();

        public async Task<Review> GetByIdAsync(int reviewId)
            => await Context
            .Reviews
            .FirstOrDefaultAsync(r => r.Id == reviewId);
    }
}