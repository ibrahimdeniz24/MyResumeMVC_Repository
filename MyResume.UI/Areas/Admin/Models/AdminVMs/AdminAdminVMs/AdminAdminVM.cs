namespace MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAdminVMs
{
    public class AdminAdminVM
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
        public IFormFile? NewPicture { get; set; }

        public string? Country { get; set; }
    }
}
