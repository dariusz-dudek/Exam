namespace Exam.Data.DAL.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ExamContext context) : base(context)
        {
        }

        public void DecreasingCounter(int authorId)
        {
            var author = Context.Authors.FirstOrDefault(a => a.Id == authorId);
            _ = author.Counter == 0 ? author.Counter = 0 : author.Counter--;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
            => await Context
            .Authors
            .Include(a => a.Materials)
            .Include(a => a.Reviews)
            .ToListAsync();

        public async Task<Author> GetByIdAsync(int authorId)
            => await Context
            .Authors
            .FirstOrDefaultAsync(a => a.Id == authorId);

        public void IncreasingCounter(int authorId)
        {
            var author = Context.Authors.FirstOrDefault(a => a.Id == authorId);
            author.Counter++;
        }

        public async Task<bool> IsExistByNameAsync(string name)
            => await Context
            .Authors
            .AnyAsync(a => a.Name == name);

        public async Task<Author> GetAuthorByNameAndPasswordAsync(string name, string password)
            => await Context.Authors.FirstOrDefaultAsync(a => a.Name == name && a.Password == HashPassword(password));

        public string HashPassword(string password)
        {
            var hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);
            var stringToReturn = Convert.ToHexString(hashedPassword);
            return stringToReturn;
        }

        public new void Create(Author entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.Password = HashPassword(entity.Password);
            Context.Authors.Add(entity);
        }

        public new void Update(Author entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.Password = HashPassword(entity.Password);
            Context.Authors.Update(entity);
        }
    }
}