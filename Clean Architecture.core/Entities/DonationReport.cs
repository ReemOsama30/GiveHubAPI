
using Clean_Architecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class DonationReport:IsoftDeletable
    {
        public int id { get; set; }
        public string Description { get; set; }
        public string Results { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public bool IsDeleted { get; set; }
    }
}
