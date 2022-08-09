namespace Exam.API.DTO.AuthorDTO
{
    public class AuthorPatchDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        [RegularExpression(@"^(Admin|User)$", ErrorMessage = "You mast enter Admin or User")]
        public string Role { get; set; }
    }
}