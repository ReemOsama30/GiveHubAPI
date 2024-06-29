using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;


namespace Clean_Architecture.core.Entities
{
    public class AwardedBadge : IsoftDeletable
    {
        public bool IsDeleted { get ; set ; }
       
        public int Id { get; set; }
        public DateTime DateReceived { get; set; }


        [ForeignKey("Badge")]
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }

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

