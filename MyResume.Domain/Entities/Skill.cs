using MyResume.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Entities
{
    public   class Skill :BaseEntity
    {
       

        public string Title { get; set; }

        public int Value { get; set; }
    }
}
