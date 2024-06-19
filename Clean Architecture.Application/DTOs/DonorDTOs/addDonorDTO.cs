using Microsoft.AspNetCore.Http;

namespace Clean_Architecture.Application.DTOs.DonorDTOs
{
    public class addDonorDTO
    {
        public string Name { get; set; }
        public IFormFile Img { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;
        public string ApplicationUserId { get; set; }

    }
}
