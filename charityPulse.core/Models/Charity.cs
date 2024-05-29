﻿using charityPulse.core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Charity:ISoftDeletable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public byte[] ProfileImg { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Donation>? Donations { get; set; }
        public ICollection<Advertisment>? Advertisments { get; set; }


    }
}