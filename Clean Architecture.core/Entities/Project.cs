
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Project:IsoftDeletable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal FundingGoal { get; set; }
        public decimal AmountRaised { get; set; }
        public string Img { get; set; }
        public ProjectState State { get; set; } = ProjectState.Initiated;

        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Report")]
        public int? ReportId { get; set; }
        public DonationReport? Report { get; set; }

        [ForeignKey("Charity")]
        public int CharityId { get; set; }
        public Charity Charity { get; set; }

        public ICollection<Donation> Donations { get; set; }


        //
    }
}
