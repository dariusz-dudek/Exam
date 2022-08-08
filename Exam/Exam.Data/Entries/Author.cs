namespace Exam.Data.Entries
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Counter { get; set; }
        public string Role { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}