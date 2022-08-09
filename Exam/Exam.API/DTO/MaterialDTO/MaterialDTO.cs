namespace Exam.API.DTO.MaterialsDTO
{
    public class MaterialDTO
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
        public DateTime DateOfPublishing { get; set; }
    }
}