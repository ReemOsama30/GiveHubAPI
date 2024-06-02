
using Clean_Architecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Review:IsoftDeletable
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }

        [ForeignKey("Donor")]
        public int? DonorID { get; set; } // Id of the user who posted the review
        public Donor Donor { get; set; }

        [ForeignKey("Charity")]
        public int? CharityId { get; set; } // Id of the project being reviewed
        public Charity Charity { get; set; }       
        
        // Add other relevant properties like reviewer name, project name, etc.
    }
}
