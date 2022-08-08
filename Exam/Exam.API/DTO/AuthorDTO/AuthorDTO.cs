namespace Exam.API.DTO.AuthorDTO
{
    public class AuthorDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Counter { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public IEnumerable<string> Materials { get; set; }

        public override string ToString()
        {
            string materials = Materials.ToString();
            return $"Id: [{Id}]; Name: {Name}; Counter: {Counter}; Role: {Role}; Materials: {materials}";
        }
    }
}
