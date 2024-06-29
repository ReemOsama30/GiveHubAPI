using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.BadgeDTOs
{
    public class UpdateBadgeDTO
    
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Icon { get; set; }

    }
}
