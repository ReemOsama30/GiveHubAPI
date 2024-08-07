﻿
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
    public class Donor:ApplicationUser,IsoftDeletable
    {

        public string Name { get; set; }
        public string ?ProfileImg { get; set; }
        public DateTime DateJoined { get; set; }= DateTime.Now;
        public bool IsPublic{ get; set; } = true;
        public ICollection<Donation>? Donations { get; set; }
        public ICollection<AwardedBadge>? Badges { get; set; }
        public ICollection<Review>? Reviews { get; set; }


    }
}
