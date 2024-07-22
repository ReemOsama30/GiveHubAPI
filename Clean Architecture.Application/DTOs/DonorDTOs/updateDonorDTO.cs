namespace Clean_Architecture.Application.DTOs.DonorDTOs
{
    public class updateDonorDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;
    }
}
