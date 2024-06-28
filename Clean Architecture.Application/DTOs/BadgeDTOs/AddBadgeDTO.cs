using charityPulse.core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.BadgeDTOs
{
    public class AddBadgeDTO
    {
       public string Name { get; set; }
       public string Description { get; set; }    
       public IFormFile Icon { get; set; }
      
       

    }
}
