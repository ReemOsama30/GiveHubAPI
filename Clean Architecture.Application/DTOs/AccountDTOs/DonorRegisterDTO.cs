using Clean_Architecture.core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.AccountDTOs
{
    public class DonorRegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }
        public IFormFile? ProfileImg { get; set; } = null;

    }
}
