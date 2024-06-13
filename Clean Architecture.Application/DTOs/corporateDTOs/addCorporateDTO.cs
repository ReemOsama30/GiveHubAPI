using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.corporateDTOs
{
    public class addCorporateDTO
    {
        public int Id { get; set; }
        public string CSRProgramDescription { get; set; }
        public string WebsiteUrl { get; set; }
        public IFormFile ProfileImgURL { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
