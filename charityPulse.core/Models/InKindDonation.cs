using charityPulse.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class InKindDonation:Donation,ISoftDeletable
    {
        public string ItemDescription { get; set; } // Specific to InKindDonation
        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }
    }
}
