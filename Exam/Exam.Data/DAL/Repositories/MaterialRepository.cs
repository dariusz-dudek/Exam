﻿namespace Exam.Data.DAL.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(ExamContext context) : base(context)
        {
        }
    }
}