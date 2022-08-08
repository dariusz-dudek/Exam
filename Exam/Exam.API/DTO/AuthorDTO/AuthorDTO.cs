using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
