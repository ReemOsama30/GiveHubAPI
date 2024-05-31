using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs
{
    public class addProductDTO
    {

        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int? categoryID { get; set; }

    }
}
