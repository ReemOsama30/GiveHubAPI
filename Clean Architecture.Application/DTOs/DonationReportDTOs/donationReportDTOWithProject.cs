namespace Clean_Architecture.Application.DTOs.DonationReportDTOs
{
    public class donationReportDTOWithProject
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Results { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
    }
}
