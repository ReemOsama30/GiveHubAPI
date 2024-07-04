using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.UsersDTO
{
    public class ShowUsers
    {
        public string name { get; set; }

        public string email { get; set; }
        public bool emailConfirmed { get; set; }
        public string AccountType { get; set; }
        public string image { get; set; }

    }
}
