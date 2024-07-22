using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.AwardedBadgeDTOs
{
    public class AwardBadgeDTO
    {
        public int BadgeId { get; set; }
        public string? DonorId { get; set; }
        public string? CharityId { get; set; }
       // public int? CorporateId { get; set; }
    }
}
