namespace Exam.API.DTO.ReviewDTO
{
    public class ReviewPostDTO
    {
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
