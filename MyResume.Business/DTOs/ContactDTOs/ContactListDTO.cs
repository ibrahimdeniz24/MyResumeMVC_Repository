using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.DTOs.ContactDTOs
{
    public class ContactListDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public string Adress { get; set; }
    }
}

