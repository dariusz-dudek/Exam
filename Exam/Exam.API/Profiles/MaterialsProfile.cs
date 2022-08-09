namespace Exam.API.Profiles
{
    public class MaterialsProfile : Profile
    {
        public MaterialsProfile()
        {
            CreateMap<Material, MaterialDTO>().ReverseMap();
            CreateMap<MaterialPostDTO, Material>();
            CreateMap<MaterialPatchDTO, Material>();
            CreateMap<MaterialPutDTO, Material>();
        }
    }
}
