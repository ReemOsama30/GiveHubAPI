using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean_Architecture.Application.DTOs.AccountDTOs;
using charityPulse.core.Models;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Infrastructure.Repositories;
using System.Net;

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
    

    /*
       [HttpGet("confirm-email")]
        public async Task<ActionResult<GeneralResponse>> ConfirmEmail(string userId, string token)
        {
            int maxRetryAttempts = 3;
            int retryAttempt = 0;

            while (retryAttempt < maxRetryAttempts)
            {
                try
                {
                    if (userId == null || token == null)
                    {
                        return new GeneralResponse()
                        {
                            IsPass = false,
                            Message = ModelState,
                            Status = 400
                        };
                    }

                    var user = await _accountService.FindByIdAsync(userId);

                    if (user == null)
                    {
                        return new GeneralResponse()
                        {
                            IsPass = false,
                            Message = $"Unable to load user with ID '{userId}'.",
                            Status = 400
                        };
                    }

                    //  Validates that an email confirmation token matches the specified user.
                    var result = await _accountService.ConfirmEmailAsync(user, token);

                    if (result.Succeeded)
                    {
                        return new GeneralResponse()
                        {
                            IsPass = true,
                            Message = "Email confirmed successfully",
                            Status = 200
                         
                        };
                    }
                    else
                    {
                        return new GeneralResponse()
                        {
                            IsPass = false,
                            Message = ModelState,
                            Status = 400
                          
                        };
                    }
                }
                catch (Exception ex)
                {
                    // Handle concurrency exception
                    // Log the exception for debugging purposes
                    // Optionally, wait for a short duration before retrying
                    await Task.Delay(TimeSpan.FromSeconds(1)); // Wait for 1 second before retrying
                    retryAttempt++;
                }
            }
            return new GeneralResponse()
            {
                IsPass = false,
                Message = "Error confirming email after multiple retries",
                Status = 400
                
            };
        }
*/

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




