namespace Clean_Architecture.Application.DTOs.MoneyDonationDTOs
{
    public class addMoneyDonationDTO
    {
        //public int id { set; get; }
        public DateTime DonationDate { get; set; }
        public string DonorId { get; set; }
        // public int? CorporateId { get; set; }
        public int? projectId { get; set; }
        public string? CharityId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
