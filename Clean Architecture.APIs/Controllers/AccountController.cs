using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean_Architecture.Application.DTOs.AccountDTOs;
using charityPulse.core.Models;
using Clean_Architecture.Application.services;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;


        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO UserRegisterDTO)
        {

            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterUserAsync(UserRegisterDTO);

                if (result.Succeeded)
                {
                    return Created();
                   // return Ok("Account Created");
                }

                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
            }
            return BadRequest(ModelState);
            
          

        }

        //[HttpPost("log-in")]
        //public IActionResult LogIn()
        //{

        //}
    }
}
