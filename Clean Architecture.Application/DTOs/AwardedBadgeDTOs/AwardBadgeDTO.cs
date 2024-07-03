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
        public int? DonorId { get; set; }
        public int? CharityId { get; set; }
       // public int? CorporateId { get; set; }
    }
}
