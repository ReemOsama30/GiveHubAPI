
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace charityPulse.core.Models
{
    public class Project : IsoftDeletable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal FundingGoal { get; set; }
        public decimal AmountRaised { get; set; }
        public string ImgUrl { get; set; }
        public ProjectState State { get; set; } = ProjectState.Initiated;
        public string Location { get; set; }

        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Report")]
        public int? ReportId { get; set; }
        public DonationReport? Report { get; set; }

        [ForeignKey("Charity")]
        public int CharityId { get; set; }
        public Charity Charity { get; set; }

        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public ICollection<Donation>? Donations { get; set; }


        
    }
}
