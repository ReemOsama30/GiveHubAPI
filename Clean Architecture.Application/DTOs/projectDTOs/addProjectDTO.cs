using Clean_Architecture.core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.projectDTOs
{
    public class addProjectDTO
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal FundingGoal { get; set; }
        public decimal AmountRaised { get; set; }
      public IFormFile ImgPath { get; set; }
        public ProjectState State { get; set; } = ProjectState.Initiated;
        public int CharityId { get; set; }
    }
}
