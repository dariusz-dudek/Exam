namespace Exam.API.DTO.AuthorDTO
{
    public class AuthorPostDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(Admin|User)$", ErrorMessage = "You mast enter Admin or User")]
        public string Role { get; set; }
    }
}