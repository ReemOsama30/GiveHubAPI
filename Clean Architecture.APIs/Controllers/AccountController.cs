using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean_Architecture.Application.DTOs.AccountDTOs;
using charityPulse.core.Models;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Clean_Architecture.Application.responses;

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
        public async Task<ActionResult<GeneralResponse>> Register(UserRegisterDTO UserRegisterDTO)
        {

            if (ModelState.IsValid)
            {
                IdentityResult result = await _accountService.RegisterUserAsync(UserRegisterDTO);

                if (result.Succeeded)
                {

                    GeneralResponse response = new GeneralResponse
                    {
                        IsPass = true,
                        Message = "Account Created Sucessfully",
                        Status = 200
                    };
                    return response;

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = ModelState,
                Status = 400
            };
        }

        [HttpPost("log-in")]
        public async Task<ActionResult<GeneralResponse>> LogIn(UserLogInDTO userLogInDTO)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser? UserFromDB = await _accountService.FindByNameAsync(userLogInDTO);

                if (UserFromDB != null)
                {

                    bool ValidUser = await _accountService.CheckPasswordAsync(UserFromDB, userLogInDTO.Password);

                    if (ValidUser)
                    {
                        ValidTokenDTO validToken = await _accountService.GenerateJWTtoken(UserFromDB);


                        return new GeneralResponse
                        {
                            IsPass = true,
                            Message = validToken,
                            Status = 200
                        };

                    }

                }

                return new GeneralResponse
                {
                    IsPass = false,
                    Message = "Invalid Name or Password",
                    Status = 400
                };

            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = ModelState,
                Status = 400
            };
        }
    }
}
