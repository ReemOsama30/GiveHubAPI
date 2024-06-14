using Microsoft.AspNetCore.Http;

namespace Clean_Architecture.Application.DTOs.charityDTOs
{
    public class addCharityDTO
    {
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public IFormFile ImgUrl { get; set; }
    }
}
