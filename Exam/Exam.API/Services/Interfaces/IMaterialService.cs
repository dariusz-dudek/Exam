namespace Exam.API.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDTO>> GetAllAsync();
    }
}