using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.DTOs.SocialMediaDTOs
{
    public class SocialMediaCreateDTO
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public byte[]? Icon { get; set; }
    }
}
