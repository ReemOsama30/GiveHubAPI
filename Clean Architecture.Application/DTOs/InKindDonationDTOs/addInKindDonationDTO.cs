namespace Clean_Architecture.Application.DTOs.InKindDonationDTOs
{
    public class addInKindDonationDTO
    {
        public DateTime DonationDate { get; set; } = DateTime.Now;
        public string DonorId { get; set; }
        //public int? CorporateId { get; set; }
        public int? projectId { get; set; }
        public string? CharityId { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
    }
}
