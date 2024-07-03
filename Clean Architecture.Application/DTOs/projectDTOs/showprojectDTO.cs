using Clean_Architecture.core.Enums;

namespace Clean_Architecture.Application.DTOs.projectDTOs
{
    public class showprojectDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal FundingGoal { get; set; }
        public decimal AmountRaised { get; set; }
        public string Location { get; set; }
        public string CategoryName { get; set; }

        public string ImgUrl { get; set; }
        public ProjectState State { get; set; } = ProjectState.Initiated;

        public int CharityId { get; set; }

        public string CharityName { set; get; }

        public int categoryId { get; set; }


    }
}
