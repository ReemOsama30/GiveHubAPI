namespace Clean_Architecture.Application.DTOs.MoneyDonationDTOs
{
    public class updateMoneyDonationDTO
    {
        public int id { get; set; }
        public DateTime DonationDate { get; set; }
        public int DonorId { get; set; }
        public int? CorporateId { get; set; }
        public int? projectId { get; set; }
        public int? CharityId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
