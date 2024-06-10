using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.InKindDonationDTOs
{
    public class showInKindDonationDTO
    {
        public DateTime DonationDate { get; set; }
        public int DonorId { get; set; }
        public int? CorporateId { get; set; }
        public int? projectId { get; set; }
        public int? CharityId { get; set; }
        public string ItemDescription { get; set; } // Specific to InKindDonation
        public int Quantity { get; set; }
    }
}
