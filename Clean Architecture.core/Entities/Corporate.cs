
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Corporate:IsoftDeletable
    {
        public int Id { get; set; }
        public string CSRProgramDescription { get; set; }
        public string WebsiteUrl { get; set; }
        public string ProfileImg { get; set; }
            public bool IsDeleted { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Donation>? Donations { get; set; }
        public ICollection<Advertisment>? Advertisments { get; set; }
        public ICollection<AwardedBadge>? Badges { get; set; }
    }
}
