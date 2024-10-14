using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.DTOs.ResumeDTOs
{
    public class ResumeListDTO
    {
        public Guid Id { get; set; }
        public string Head { get; set; }

        public string Title { get; set; }

        public string Date { get; set; }

        public string Desciption { get; set; }
    }
}
