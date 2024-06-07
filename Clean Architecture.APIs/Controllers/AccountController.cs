using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean_Architecture.Application.DTOs.AccountDTOs;
using charityPulse.core.Models;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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
                IdentityResult result = await _accountService.RegisterUserAsync(UserRegisterDTO);

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
/*
        [HttpPost("log-in")]
        public async IActionResult LogIn(UserLogInDTO userLogInDTO)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser? UserFromDB = await _accountService.FindByNameAsync(userLogInDTO);

                if (UserFromDB != null)
                {

                    bool ValidUser = await _accountService.CheckPasswordAsync(UserFromDB, userLogInDTO.Password);

                    if (ValidUser)
                    {

                        _accountService.GenerateJWTtoken(UserFromDB);

                    }
                   
                }

                return Unauthorized("Invalid Email or Password");
            }
            return BadRequest(ModelState);
        }*/
    }
}
