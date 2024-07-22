
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Charity: ApplicationUser,IsoftDeletable
    {
   
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public string ?ProfileImg { get; set; }
        public bool IsBlocked { get; set; } = false;
        public AccountState AccountState { get; set; } = AccountState.Pending;

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Donation>? Donations { get; set; }
        public ICollection<Advertisment>? Advertisments { get; set; }

        public ICollection<AwardedBadge>? Badges { get; set; }

    }
}
