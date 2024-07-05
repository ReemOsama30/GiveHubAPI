namespace Clean_Architecture.Application.DTOs.InKindDonationDTOs
{
    public class showInKindDonationDTO
    {
        public DateTime DonationDate { get; set; }
        public int DonorId { get; set; }

        public string ProjectName { get; set; }

        public string projectImage { get; set; }
        public int? projectId { get; set; }
        public int? CharityId { get; set; }
        public string ItemDescription { get; set; } // Specific to InKindDonation
        public string charityName { get; set; }
        public string DonorName { get; set; }

        public int Quantity { get; set; }
    }
}
