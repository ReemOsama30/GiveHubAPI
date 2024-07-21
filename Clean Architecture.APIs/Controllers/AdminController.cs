using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminService;

        public AdminController(AdminService adminService)
        {
            this.adminService = adminService;
        }


        [HttpGet]
        public ActionResult<GeneralResponse> GetAllNotifications()
        {
            var Notification = adminService.GetAllNotification();
            if (Notification != null)
            {

                return new GeneralResponse
                {
                    IsPass = true,
                    Message = Notification,
                    Status = 200
                };

            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Message = "there is no new Notification",
                    Status = 400
                };
            }

        }

        [HttpPatch]
        public ActionResult<GeneralResponse> BlockUsers(int id)
        {

            bool isblocked = adminService.BlockCharity(id);
            if (isblocked) {


                return new GeneralResponse
                {
                    IsPass = true,
                    Message = "the user is blocked successfully"
                };
            }
            return new GeneralResponse
            {
                IsPass=false,
                Message="invalid user"
            };

        }
    }
}