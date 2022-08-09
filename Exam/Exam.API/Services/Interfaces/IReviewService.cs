namespace Exam.API.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetAll();

        Task<int> CreateNewAsync(ReviewPostDTO reviewPostDTO);

        Task<int> PutAsync(ReviewPutDTO reviewPutDTO);

        Task<int> DeleteReviewAsync(int reviewId);
    }
}