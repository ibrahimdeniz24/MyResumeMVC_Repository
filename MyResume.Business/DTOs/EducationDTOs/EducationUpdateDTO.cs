using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.DTOs.EducationDTOs
{
    public class EducationUpdateDTO
    {
        public Guid Id { get; set; }
        public string School { get; set; }

        public string Departman { get; set; }

        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? Description { get; set; }
    }
}
