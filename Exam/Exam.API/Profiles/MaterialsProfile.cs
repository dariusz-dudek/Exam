
namespace Exam.API.Profiles
{
    public class MaterialsProfile : Profile
    {
        public MaterialsProfile()
        {
            CreateMap<Material, MaterialDTO>().ReverseMap();
            //.ForMember(dest => dest.Reviews,
            //opt => opt.MapFrom<MaterislIncludesResorver>());
        }

    }

    //public class MaterislIncludesResorver : IValueResolver<Material, MaterialsDTO, IEnumerable<string>>
    //{
    //    public IEnumerable<string> Resolve(Material source, MaterialsDTO destination, IEnumerable<string> destMember, ResolutionContext context)
    //    {
    //        var reviews = new List<string>();
    //        if (source.Rewievs != null && source.Rewievs.Any())
    //        {
    //            foreach (var review in source.Rewievs)
    //            {
    //                reviews.Add(review.RevievPoints.ToString());
    //            }
    //        }
    //        return reviews.AsEnumerable();
    //    }
    //}
}
