﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.AccountDTOs
{
    internal class RegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AccountType { get; set; }
    }
}
