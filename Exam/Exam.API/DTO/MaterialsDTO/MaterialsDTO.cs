using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.API.DTO.MaterialsDTO
{
    public class MaterialsDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public MaterialType MaterialType { get; set; }
        [Required]
        public Author Author { get; set; }
        [Required]
        public IEnumerable<Review> Rewievs { get; set; }
        [Required]
        public DateTime DateOfPublishing { get; set; }
    }
}
