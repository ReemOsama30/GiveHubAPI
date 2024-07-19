using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.DonorDTOs
{
    public class DonorsProfilsDTO
    {

        public string Name { get; set; }
        public string ProfileImg { get; set; }

        public DateTime DateJoined { get; set; }

        public bool IsPublic { get; set; }
    }
}
