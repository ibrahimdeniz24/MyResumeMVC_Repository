using MyResume.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Entities
{
    public class About :BaseEntity
    {
        public string Head { get; set; }
        public string HeadDesciprtion { get; set; }
        public byte[]? ProfilePicture { get; set; }

        public string Title { get; set; }

        public string TitleDescription { get; set; }
        public string SubDescription { get; set; }
        public string Degree { get; set; }

        public DateTime BirthDate { get; set; }
        public int? Age { get; set; }
        public string WebSite { get; set; }
        public string Phone { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
        public string FreeLance { get; set; }




    }
}
