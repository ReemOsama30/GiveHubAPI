using Clean_Architecture.Application.DTOs.UsersDTO;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices userServices;

        public UserController(UserServices userServices)
        {
            this.userServices = userServices;
        }



        [HttpGet] 
        public ActionResult<GeneralResponse>GetUsers()
        {
       List<ShowUsers>users=  userServices.GetAllUsers();
            if (users.Count > 0)
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Message=users,
                    Status = 200
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = "no users",
                Status = 200
            };

        }

    }
}
