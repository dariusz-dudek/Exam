namespace Exam.API.DTO.AuthorDTO
{
    public class AuthorPutDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(Admin|User)$", ErrorMessage = "You mast enter Admin or User")]
        public string Role { get; set; }
    }
}