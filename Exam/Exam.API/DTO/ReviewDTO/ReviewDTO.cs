using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.API.DTO.ReviewDTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string RewievText { get; set; }
        public int RevievPoints { get; set; }
        public int MaterialId { get; set; }
        public int AuthorId { get; set; }
    }
}
