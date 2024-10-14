namespace MyResume.UI.Areas.Admin.Models.AdminVMs.AdminSocialMediaVMs
{
    public class AdminSocialMediaCreateVM
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public IFormFile NewIcon { get; set; }
    }
}
