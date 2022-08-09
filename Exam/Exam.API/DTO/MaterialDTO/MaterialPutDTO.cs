namespace Exam.API.DTO.MaterialDTO
{
    public class MaterialPutDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Location { get; set; } = null!;
        [Required]
        public int MaterialTypeId { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}