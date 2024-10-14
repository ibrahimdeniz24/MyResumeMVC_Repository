using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.DTOs.PortfolioDTOs
{
    public class PortfolioUpdateDTO
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }

        public DateTime ProjectDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public string Url { get; set; }
    }
}
