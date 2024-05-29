using charityPulse.core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Advertisment:ISoftDeletable
    {
       
        public int Id { get; set; }
        public byte[] AdDesign { get; set; }

        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Duration { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Charity")]
        public int? CharityId { get; set; }
        public Project? Charity { get; set; }

        [ForeignKey("Corporate")]
        public int? CorporateId { get; set; }
        public Corporate? Corporate { get; set; }

    }
}
