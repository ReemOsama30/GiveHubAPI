using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.DonationDTOs
{
    public class GeneralDonationDTO
    {
        public DateTime DonationDate { get; set; } = DateTime.Now;
        public int DonorId { get; set; }
        //public int? CorporateId { get; set; }
        public int? projectId { get; set; }
        public int? CharityId { get; set; }

        public decimal? Amount { get; set; }
        //public string PaymentMethod { get; set; }
    }
}
