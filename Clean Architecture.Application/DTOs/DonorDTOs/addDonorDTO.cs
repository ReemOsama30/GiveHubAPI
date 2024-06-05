namespace Clean_Architecture.Application.DTOs.DonorDTOs
{
    public class addDonorDTO
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;
    }
}
