using MyResume.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Entities
{
    public class Portfolio :BaseEntity
    {
       

 
        public string ProjectName { get; set; }

        public DateTime ProjectDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public string Url { get; set; }

    }
}
