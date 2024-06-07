
using Clean_Architecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Badge:IsoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateRecived { get; set; }
        public byte[] Icon { get; set; }
        public bool IsDeleted { get; set; }
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
