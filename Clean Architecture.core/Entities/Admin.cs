
using Clean_Architecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Models
{
    public class Admin:IsoftDeletable
    {
        public int id { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
