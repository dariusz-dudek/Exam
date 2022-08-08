namespace Exam.API.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(dest => dest.Materials,
                opt => opt.MapFrom<AuthorMaterialsIncludesResolver>())
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom<AuthorReviewsIncludesResolver>());

            CreateMap<AuthorPostDTO, Author>();
        }
    }

    public class AuthorMaterialsIncludesResolver : IValueResolver<Author, AuthorDTO, IEnumerable<string>>
    {
        public IEnumerable<string> Resolve(Author source, AuthorDTO destination, IEnumerable<string> destMember, ResolutionContext context)
        {
            var materials = new List<string>();
            if (source.Materials != null && source.Materials.Any())
            {
                foreach (var material in source.Materials)
                {
                    materials.Add(material.Title);
                }
            }
            return materials.AsEnumerable();
        }
    }

    public class AuthorReviewsIncludesResolver : IValueResolver<Author, AuthorDTO, IEnumerable<string>>
    {
        public IEnumerable<string> Resolve(Author source, AuthorDTO destination, IEnumerable<string> destMember, ResolutionContext context)
        {
            var reviewers = new List<string>();
            if (source.Reviews != null && source.Reviews.Any())
            {
                foreach (var review in source.Reviews)
                {
                    reviewers.Add(review.RewievText);
                }
            }
            return reviewers.AsEnumerable();
        }
    }
}
