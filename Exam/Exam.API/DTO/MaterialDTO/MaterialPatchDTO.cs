using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.API.DTO.MaterialDTO
{
    public class MaterialPatchDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int? MaterialTypeId { get; set; }
        public int? AuthorId { get; set; }
    }
}
