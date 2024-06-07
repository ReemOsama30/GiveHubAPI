
using Clean_Architecture.Application.Interfaces;
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
        public string? AccountType { get; set; } = "Donor";
        public bool IsDeleted { get; set; }

        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }

        [ForeignKey("Donor")]
        public int? DonorId { get; set; }
        public Donor? Donor { get; set; }

        [ForeignKey("Charity")]
        public int? CharityId { get; set; }
        public Charity? Charity { get; set; }

        [ForeignKey("Corporate")]
        public int? CorporateId { get; set; }
        public Corporate? Corporate { get; set; }

       
    }
}
