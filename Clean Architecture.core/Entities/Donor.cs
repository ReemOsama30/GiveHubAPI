
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
    public class Donor:IsoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImg { get; set; }
        public DateTime DateJoined { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Donation>? Donations { get; set; }
        public ICollection<AwardedBadge>? Badges { get; set; }
        public ICollection<Review>? Reviews { get; set; }

       // public ICollection<Project>? Projects { get; set; }

    }
}
