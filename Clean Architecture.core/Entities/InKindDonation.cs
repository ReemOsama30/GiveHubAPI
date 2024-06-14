
using Clean_Architecture.Application.Interfaces;

namespace charityPulse.core.Models
{
    public class InKindDonation : Donation, IsoftDeletable
    {
        public string ItemDescription { get; set; } // Specific to InKindDonation
        public int Quantity { get; set; }


    }
}
