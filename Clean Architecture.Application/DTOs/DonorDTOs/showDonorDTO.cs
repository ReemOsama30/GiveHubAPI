namespace Clean_Architecture.Application.DTOs.DonorDTOs
{
    public class showDonorDTO
    {
        public string Name { get; set; }
        public byte[] ProfileImg { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;
    }
}
