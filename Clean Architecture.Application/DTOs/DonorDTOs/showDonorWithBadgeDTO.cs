namespace Clean_Architecture.Application.DTOs.DonorDTOs
{
    public class showDonorWithBadgeDTO
    {
        public string Name { get; set; }
        public byte[] ProfileImg { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;

        public List<string> BadgeName { get; set; }
    }
}
