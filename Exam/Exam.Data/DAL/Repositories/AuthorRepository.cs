﻿
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
    }
}