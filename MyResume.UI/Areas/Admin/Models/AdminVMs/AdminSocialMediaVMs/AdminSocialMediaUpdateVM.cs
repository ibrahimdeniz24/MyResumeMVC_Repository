namespace MyResume.UI.Areas.Admin.Models.AdminVMs.AdminSocialMediaVMs
{
    public class AdminSocialMediaUpdateVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Url { get; set; }

        public IFormFile  NewIcon { get; set; }
    }
}
