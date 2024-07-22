
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{public class ApplicationUser:IdentityUser,IsoftDeletable
{
        public AccountType accountType { get; set; } = AccountType.Donor;
        public bool IsDeleted { get; set; } = false;
      
  
       
    }
}
