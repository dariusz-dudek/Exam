namespace Exam.API.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDTO>> GetAllAsync();
        Task<int> CreateNewAsync(MaterialPostDTO materialPostDTO);
    }
}