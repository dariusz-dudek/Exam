namespace Exam.API.DTO.MaterialDTO
{
    public class MaterialPostDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int MaterialTypeId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}