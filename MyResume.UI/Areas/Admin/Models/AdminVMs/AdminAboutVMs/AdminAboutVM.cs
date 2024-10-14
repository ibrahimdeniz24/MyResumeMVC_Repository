namespace MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAboutVMs
{
    public class AdminAboutVM
    {
        public Guid Id { get; set; }
        public string Head { get; set; }
        public string HeadDesciprtion { get; set; }

        public byte[]? ProfilePicture { get; set; }
        public string Title { get; set; }

        public string TitleDescription { get; set; }
        public string SubDescription { get; set; }
        public string Degree { get; set; }

        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string WebSite { get; set; }
        public string Phone { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
        public string FreeLance { get; set; }
    }
}
