using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.core.Entities
{
    public class Notification:IsoftDeletable
    {

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public bool IsRead { get; set; }

        public string AdminId { get; set; }
        public ApplicationUser ?Admin { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
