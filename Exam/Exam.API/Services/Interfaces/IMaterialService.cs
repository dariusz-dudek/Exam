namespace Exam.API.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDTO>> GetAllAsync();
        Task<int> CreateNewAsync(MaterialPostDTO materialPostDTO);
        Task<int> UpdateMaterialAsync(int materialId, MaterialPatchDTO materialPatchDTO);
        Task<int> DeleteMaterialAsync(int id);
        Task<int> PutAsync(MaterialPutDTO authorPutDTO);
    }
}