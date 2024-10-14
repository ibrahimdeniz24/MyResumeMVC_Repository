namespace MyResume.UI.Areas.Admin.Models.AdminVMs.AdminSocialMediaVMs
{
    public class AdminSocialMediaListVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Url { get; set; }

        public byte[]? Icon { get; set; }
    }
}
