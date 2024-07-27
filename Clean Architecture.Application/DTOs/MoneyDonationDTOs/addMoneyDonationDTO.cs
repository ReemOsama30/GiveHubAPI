namespace Clean_Architecture.Application.DTOs.MoneyDonationDTOs
{
    public class addMoneyDonationDTO
    {

        public DateTime DonationDate { get; set; } = DateTime.Now;
        public string DonorId { get; set; }
     
        public int? projectId { get; set; }
        public string? CharityId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
