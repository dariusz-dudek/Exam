namespace Exam.Data.Entries
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public MaterialType MaterialType { get; set; }
        public int MaterialTypeId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<Review> Rewievs { get; set; }
        public DateTime DateOfPublishing { get; set; } = DateTime.Now;
    }
}