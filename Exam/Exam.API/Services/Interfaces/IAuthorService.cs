namespace Exam.API.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAll();

        Task<int> CreateNewAsync(AuthorPostDTO authorPostDTO);

        Task<bool> IsExistByNameAsync(string name);

        Task<int> PutAsync(AuthorPutDTO authorPutDTO);

        Task<int> UpdateAuthorAsync(int authorId, AuthorPatchDTO authorPatchDTO);

        Task<int> DeleteAuthorAsync(int authorId);
    }
}