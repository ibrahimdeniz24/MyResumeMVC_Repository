namespace MyResume.UI.Models.ViewModels.MessageVM
{
    public class MessageCreateVM
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }

        public string? Subject { get; set; }

        public string? MessageDetail { get; set; }

        public DateTime? SendDate { get; set; }

        public bool? IsRead { get; set; }

        public string RecaptchaToken { get; set; }

    }
}
