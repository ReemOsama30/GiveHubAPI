namespace Clean_Architecture.Application.DTOs.DonorDTOs
{
    public class showDonorDTO
    {
        public string Name { get; set; }
        public string ProfileImgURL { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;
    }
}
