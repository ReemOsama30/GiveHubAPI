using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Runtime.Intrinsics.X86;
using System;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //[HttpPost("register")]
        //public IActionResult Regeister() {

        //}

        [HttpGet("register")]
        public IActionResult Register()
        {
            var redirectUrl = Url.Action(nameof(RegisterCallback), "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        // This action handles the response from Google after the user has authenticated for registration.
        [HttpGet("register-callback")]
        public async Task<IActionResult> RegisterCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
                return BadRequest(); // Handle error

            var claims = result.Principal.Identities
                .FirstOrDefault()?.Claims.Select(claim => new
                {
                    claim.Type,
                    claim.Value
                });

            // Logic to handle user registration
            // For now, just return the claims for testing purposes
            return Ok(claims);
        }
    }
}



