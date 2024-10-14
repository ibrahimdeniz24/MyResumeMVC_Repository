using MyResume.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Entities
{
    public class Summary :BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
