namespace Clean_Architecture.Application.DTOs.MoneyDonationDTOs
{
    public class showMoneyDonationDTO
    {
        public int id { set; get; }
        public DateTime DonationDate { get; set; }
        public int DonorId { get; set; }
        public int? projectId { get; set; }

        public string ProjectName { get; set; }

        public string projectImage { get; set; }
        public int? CharityId { get; set; }

        public string charityName { get; set; }
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }

    }
}
