namespace MyResume.UI.Areas.Admin.Models.AdminVMs.AdminEducationVMs
{
    public class AdminEducationCreateVM
    {
        public string School { get; set; }

        public string Departman { get; set; }

        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? Description { get; set; }
    }
}
