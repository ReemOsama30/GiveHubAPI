namespace Clean_Architecture.Application.DTOs.client
{
    public class DonationOrderRequestDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string PaypalOrderId { get; set; }
    }
}
