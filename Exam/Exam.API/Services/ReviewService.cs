namespace Exam.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMaterialRepository _materialRepository;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IAuthorRepository authorRepository, IMaterialRepository materialRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _materialRepository = materialRepository;
        }

        public async Task<int> CreateNewAsync(ReviewPostDTO reviewPostDTO)
        {
            var review = _mapper.Map<Review>(reviewPostDTO);

            if (await _authorRepository.GetByIdAsync(review.AuthorId) == null)
                throw new ResourceNotFoundException("Author not found.");

            if (await _materialRepository.GetByIdAsync(review.MaterialId) == null)
                throw new ResourceNotFoundException("Material not found.");

            _reviewRepository.Create(review);
            await _reviewRepository.SaveChangesAsync();
            return review.Id;
        }

        public async Task<int> DeleteReviewAsync(int reviewId)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);
            if (review == null)
                throw new ResourceNotFoundException("Review not found");
            _reviewRepository.Delete(review);
            await _reviewRepository.SaveChangesAsync();
            return reviewId;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAll()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<int> PutAsync(ReviewPutDTO reviewPutDTO)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewPutDTO.Id);

            if (review == null)
                throw new ResourceNotFoundException("Review not found");

            if (await _authorRepository.GetByIdAsync(reviewPutDTO.AuthorId) == null)
                throw new ResourceNotFoundException("Author not found");
            review.AuthorId = reviewPutDTO.AuthorId;

            if (await _materialRepository.GetByIdAsync(reviewPutDTO.MaterialId) == null)
                throw new ResourceNotFoundException("Material not found");
            review.MaterialId = reviewPutDTO.MaterialId;

            review.RewievText = reviewPutDTO.RewievText;

            review.RevievPoints = reviewPutDTO.RevievPoints;

            _reviewRepository.Update(review);
            await _reviewRepository.SaveChangesAsync();
            return review.Id;
        }
    }
}
