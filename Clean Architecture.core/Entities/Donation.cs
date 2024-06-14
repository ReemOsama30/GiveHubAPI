
using Clean_Architecture.Application.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace charityPulse.core.Models
{
    public class Donation : IsoftDeletable
    {
        public int Id { get; set; }

        public DateTime DonationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        [ForeignKey("Donor")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; }

        [ForeignKey("Corporate")]
        public int? CorporateId { get; set; }
        public Corporate? Corporate { get; set; }

        [ForeignKey("Project")]
        public int? projectId { get; set; }
        public Project? Project { get; set; }

        [ForeignKey("Charity")]
        public int? CharityId { get; set; }
        public Charity? Charity { get; set; }




    }
}
