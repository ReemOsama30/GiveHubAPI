using charityPulse.core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Donation:ISoftDeletable
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        [ForeignKey ("Donor")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; }

        [ForeignKey("Corporate")]
        public int? CorporateId { get; set; }
        public Corporate? Corporate { get; set; }

        
    }
}
