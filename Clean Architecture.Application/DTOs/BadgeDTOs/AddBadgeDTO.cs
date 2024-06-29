using Microsoft.AspNetCore.Http;


namespace Clean_Architecture.Application.DTOs.BadgeDTOs
{
    public class AddBadgeDTO
    {
       public string Name { get; set; }
       public string Description { get; set; }    
       public IFormFile Icon { get; set; }
      
    }
}
