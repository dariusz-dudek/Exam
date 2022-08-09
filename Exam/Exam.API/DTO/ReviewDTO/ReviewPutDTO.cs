namespace Exam.API.DTO.ReviewDTO
{
    public class ReviewPutDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string RewievText { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Range is from 1 to 10")]
        public int RevievPoints { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}