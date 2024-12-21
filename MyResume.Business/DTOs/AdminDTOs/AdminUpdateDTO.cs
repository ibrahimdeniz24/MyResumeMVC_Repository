using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.DTOs.AdminDTOs
{
    public class AdminUpdateDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentityId { get; set; }

        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public DateTime? BirthDate { get; set; }
        public byte[]? ProfilePicture { get; set; }

        public string? Country { get; set; }
    }
}
