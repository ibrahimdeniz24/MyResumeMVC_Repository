namespace MyResume.UI.Models.ViewModels.PortfolioVM
{
    public class PortfolioDetailVM
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }

        public DateTime ProjectDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public string Url { get; set; }
    }
}
