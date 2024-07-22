
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
        public string DonorId { get; set; }
        public Donor Donor { get; set; }

     
        [ForeignKey("Project")]
        public int? projectId { get; set; }
        public Project? Project { get; set; }

        [ForeignKey("Charity")]
        public string? CharityId { get; set; }
        public Charity? Charity { get; set; }




    }
}
