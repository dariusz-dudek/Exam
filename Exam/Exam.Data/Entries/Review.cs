namespace Exam.Data.Entries
{
    public class Review
    {
        public int Id { get; set; }
        public string RewievText { get; set; }
        public int RevievPoints { get; set; }
        public Material Material { get; set; }
        public int MaterialId { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}