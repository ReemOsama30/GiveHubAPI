using Clean_Architecture.core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.projectDTOs
{
    public class updateProjectDTO
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal FundingGoal { get; set; }
        public decimal AmountRaised { get; set; }
        public IFormFile Imgpath { get; set; }
        public int CharityId { get; set; }
        public ProjectState State { get; set; } = ProjectState.Initiated;
        public string Location { get; set; }
        public string Category { get; set; }
    }
}
