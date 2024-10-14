using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.DTOs.SkillDTOs
{
    public class SkillListDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public int Value { get; set; }
    }
}
