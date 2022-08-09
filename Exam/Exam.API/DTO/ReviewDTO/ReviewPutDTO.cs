namespace Exam.API.DTO.ReviewDTO
{
    public class ReviewPutDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string RewievText { get; set; }

        [Required]
        public int RevievPoints { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}