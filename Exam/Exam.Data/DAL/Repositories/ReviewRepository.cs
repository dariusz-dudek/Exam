namespace Exam.Data.DAL.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ExamContext context) : base(context)
        {
        }
    }
}