
namespace Exam.Data.DAL.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ExamContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
            => await Context
            .Authors
            .Include(a => a.Materials)
            .Include(a => a.Reviews)
            .ToListAsync();

        public async Task<Author> GetById(int authorId)
            => await Context
            .Authors
            .FirstOrDefaultAsync(a => a.Id == authorId);

        public async Task<bool> IsExistByNameAsync(string name)
            => await Context
            .Authors
            .AnyAsync(a => a.Name == name);
    }
}