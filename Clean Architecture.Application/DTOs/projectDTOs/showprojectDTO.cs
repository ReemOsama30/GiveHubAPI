using Clean_Architecture.core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.projectDTOs
{
    public class showprojectDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal FundingGoal { get; set; }
        public decimal AmountRaised { get; set; }
        public byte[] Img { get; set; }
        public ProjectState State { get; set; } = ProjectState.Initiated;

    }
}
