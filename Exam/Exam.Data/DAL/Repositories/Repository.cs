namespace Exam.Data.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ExamContext _context;
        public ExamContext Context { get => _context; }

        public Repository(ExamContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
            => await _context.SaveChangesAsync() > 0;

        public void Update(T entity)
        { }
    }
}