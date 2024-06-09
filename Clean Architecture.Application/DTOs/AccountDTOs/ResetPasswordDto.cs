using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.AccountDTOs
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string oldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
