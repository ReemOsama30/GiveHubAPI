namespace Clean_Architecture.Application.DTOs.InKindDonationDTOs
{
    public class updateInKindDonationDTO
    {
        public DateTime DonationDate { get; set; } = DateTime.Now;
        public int DonorId { get; set; }
        //public int? CorporateId { get; set; }
        public int? projectId { get; set; }
        public int? CharityId { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
    }
}
