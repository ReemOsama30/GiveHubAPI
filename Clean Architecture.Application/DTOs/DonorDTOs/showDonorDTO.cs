namespace Clean_Architecture.Application.DTOs.DonorDTOs
{
    public class showDonorDTO
    {
        public string ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string ProfileImg { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;

       


    }
}
