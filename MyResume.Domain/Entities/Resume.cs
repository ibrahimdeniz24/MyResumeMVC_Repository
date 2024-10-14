using MyResume.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Entities
{
    public class Resume :BaseEntity
    {
        
        public string Head   { get; set; }

        public string Title { get; set; }

        public string Date { get; set; }

        public string Desciption { get; set; }
    }
}
