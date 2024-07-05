using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.AccountDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = "Account Already Taken",
                Status = 400
            };
        }



        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Invalid email confirmation request.");
            }


            var user = await _accountService.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }



            var result = await _accountService.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return Ok("Email confirmed successfully.");
            }

            return BadRequest("Error confirming email.");
        }


        [HttpPost("log-in")]
        public async Task<ActionResult<GeneralResponse>> LogIn(UserLogInDTO userLogInDTO)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser? UserFromDB = await _accountService.FindByNameAsync(userLogInDTO);

                if (UserFromDB != null)
                {

                    if (!UserFromDB.EmailConfirmed)
                    {
                        return new GeneralResponse
                        {
                            IsPass = false,
                            Message = "Email not confirmed",
                            Status = 400
                        };
                    }
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


        [HttpPost("reset-password")]
        public async Task<ActionResult<GeneralResponse>> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var result = await _accountService.ResetPasswordAsync(resetPasswordDto);
            if (result.IsPass)
            {
                return Ok(result); // Password reset successfully
            }
            else
            {
                return BadRequest(result); // Failed to reset password
            }

        }

    }
}




