namespace Exam.API.Profiles
{
    public class ReviewProfole : Profile
    {
        public ReviewProfole()
        {
            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewPostDTO, Review>();
            CreateMap<ReviewPutDTO, Review>();
        }
    }
}
