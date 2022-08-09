namespace Exam.Data.Context
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>(a =>
            {
                a.HasKey(a => a.Id);
                a.HasIndex(a => a.Name).IsUnique();
            });

            builder.Entity<Material>(m =>
            {
                m.HasKey(m => m.Id);
            });

            builder.Entity<MaterialType>(mt =>
            {
                mt.HasKey(mt => mt.MaterialTypeId);
                mt.HasIndex(mt => mt.Name).IsUnique();
            });

            builder.Entity<Review>(r =>
            {
                r.HasKey(r => r.Id);
                r.HasOne(r => r.Material).WithMany(m => m.Rewievs).OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}