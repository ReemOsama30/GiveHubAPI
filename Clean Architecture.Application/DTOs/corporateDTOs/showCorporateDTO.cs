using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.corporateDTOs
{
    public class showCorporateDTO
    {
        public int Id { get; set; }
        public string CSRProgramDescription { get; set; }
        public string WebsiteUrl { get; set; }
        public string ProfileImgURL { get; set; }
    }
}
