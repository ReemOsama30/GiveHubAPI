using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.AccountDTOs
{
    public class UserLogInDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
