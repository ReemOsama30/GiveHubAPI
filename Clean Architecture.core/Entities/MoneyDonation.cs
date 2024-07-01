
using Clean_Architecture.Application.Interfaces;

namespace charityPulse.core.Models
{
    public class MoneyDonation : Donation, IsoftDeletable
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Specific to MonetaryDonation
    

    }
}
