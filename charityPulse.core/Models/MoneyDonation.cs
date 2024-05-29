using charityPulse.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class MoneyDonation:Donation,ISoftDeletable
    {
        public string PaymentMethod { get; set; } // Specific to MonetaryDonation
        public bool IsDeleted { get; set; }
    }
}
