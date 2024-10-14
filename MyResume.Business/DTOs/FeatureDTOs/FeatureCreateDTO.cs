using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.DTOs.FeatureDTOs
{
    public class FeatureCreateDTO
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string? Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Title3 { get; set; }
    }
}
