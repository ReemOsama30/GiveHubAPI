using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.AccountDTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Clean_Architecture.Application.responses;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using System.Net;


namespace Clean_Architecture.Application.services
{
    public class AccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IEmailService emailService;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper,
            IConfiguration config, SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor,
            IEmailService emailService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.config = config;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
            this.emailService = emailService;
        }


        public async Task<IdentityResult> RegisterUserAsync(UserRegisterDTO userDTO)
        {
            //modify it to use autoMapper instead

            ApplicationUser user = new ApplicationUser()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                AccountType = userDTO.AccountType,
            };




            var result = await unitOfWork.UserRepository.CreateUserAsync(user, userDTO.Password);
            await SendConfirmationEmail(userDTO.Email, user);
            if (result.Succeeded)
            {
                await unitOfWork.SaveAsync();
            }
            return result;
        }

        public async Task<ApplicationUser> FindByNameAsync(UserLogInDTO userDTO)
        {

            ApplicationUser user = await unitOfWork.UserRepository.FindByNameAsync(userDTO.UserName);
            return user;
        }
        public async Task<ApplicationUser> FindByIdAsync(string userID)
        {
            ApplicationUser user = await unitOfWork.UserRepository.FindByIdAsync(userID);
            return user;
        }
        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            ApplicationUser user = await unitOfWork.UserRepository.FindByEmailAsync(email);
            return user;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            var result = await unitOfWork.UserRepository.ConfirmEmailAsync(user, token);
            return result;
        }
        public async Task<bool> CheckPasswordAsync(ApplicationUser UserFromDB, string PasswordFromDTO)
        {
            bool result = await unitOfWork.UserRepository.CheckPasswordAsync(UserFromDB, PasswordFromDTO);
            return result;

        }
        public async Task<GeneralResponse> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
            {
                return new GeneralResponse { IsPass = false, Message = "User not found." };
            }

            var signInResult = await unitOfWork.UserRepository.CheckPasswordAsync(user, resetPasswordDto.oldPassword);
            if (!signInResult)
            {
                return new GeneralResponse { IsPass = false, Message = "Invalid password." };
            }

            var token = await unitOfWork.UserRepository.GeneratePasswordResetTokenAsync(user);
            var result = await unitOfWork.UserRepository.ResetPasswordAsync(user, token, resetPasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return new GeneralResponse { IsPass = true, Message = "Password reset successfully." };
            }
            else
            {
                return new GeneralResponse { IsPass = false, Message = "Failed to reset password." };
            }
        }

        private async Task SendConfirmationEmail(string? email, ApplicationUser? user)
        {
            string token = await unitOfWork.UserRepository.GenerateEmailConfirmationTokenAsync(user);
            token = WebUtility.UrlEncode(token);

            HttpRequest Request = httpContextAccessor.HttpContext.Request;

            string confirmationLink = $"{Request.Scheme}://{Request.Host}/api/Account/confirm-email?userId={user.Id}&token={token}";
            string mailBody = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <title>GiveHub Email Confirmation</title>\r\n  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n   <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet'>\r\n  <style>\r\n body{{\r\n background: #eeeeee;\r\n      margin: 0;\r\n      padding: 0;\r\n    }}\r\n    .container {{\r\n      max-width: 640px;\r\n      margin: 0 auto;\r\n      background: #ffffff;\r\n      box-shadow: 0px 1px 5px rgba(0, 0, 0, 0.1);\r\n      border-radius: 4px;\r\n      overflow: hidden;\r\n    }}\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n    <div style=\"background-color: #77d986 ; padding: 57px; text-align: center;\">\r\n      <div style=\"cursor: auto; color: white; font-family: Poppins, sans-serif; font-size: 36px; font-weight: 600;\">\r\n        Welcome to GiveHub!\r\n      </div>\r\n    </div>\r\n    \r\n    <div style=\"padding: 40px 70px;\">\r\n      <div style=\"color: #242424 !important; font-family: Poppins, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <h2 style=\"font-weight: 500; font-size: 20px; color: #1c1c1c;\">Hey {user.UserName},</h2>\r\n        <p>\r\n          Welcome aboard GiveHub! 💚 Thanks for signing up! We're thrilled to have you join our community.\r\n        </p>\r\n        <p>\r\n          To get started, we just need to confirm your email address to ensure everything runs smoothly.\r\n        </p>\r\n        <p>\r\n          Click the button below to verify your email and make this world a better place through the joy of giving .\r\n        </p>\r\n      </div>\r\n      <div style=\"text-align: center; padding: 20px;\">\r\n        <a href=\"{confirmationLink}\" style=\"display: inline-block; background-color: #77d986 ; color: white; text-decoration: none; padding: 15px 30px; border-radius: 3px;\">Verify Email</a>\r\n      </div>\r\n      <div style=\"color: #242424 !important ; font-family: Poppins, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <p>If you have any questions or need assistance, feel free to reach out to our support team.</p>\r\n        <p><br>GiveHub Team</p>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</body>\r\n</html>\r\n";


            await emailService.SendEmailAsync(user.Email, "GiveHub Email Confiramtion", mailBody, true);

        }





        private async Task<List<Claim>> CreateClaims(ApplicationUser UserFromDB)
        {
            List<Claim> UserLoginClaims =
            [
                new Claim(ClaimTypes.Name, UserFromDB.UserName),
                new Claim(ClaimTypes.NameIdentifier, UserFromDB.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("AccountType", UserFromDB.AccountType)
            ];

            IList<string>? roles = await unitOfWork.UserRepository.GetRolesAsync(UserFromDB);
            foreach (string role in roles)
            {
                UserLoginClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            return UserLoginClaims;

        }
        private async Task<SigningCredentials> CreateSigningCredentials()
        {
            var SignKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(config["JWT:SecritKey"]));

            SigningCredentials signingCredentials =
                new SigningCredentials(SignKey, SecurityAlgorithms.HmacSha256);

            return signingCredentials;

        }
        public async Task<ValidTokenDTO> GenerateJWTtoken(ApplicationUser UserFromDB)
        {
            List<Claim> UserLoginClaims = await CreateClaims(UserFromDB);
            SigningCredentials signingCredentials = await CreateSigningCredentials();


            JwtSecurityToken LoginJWTToken = new JwtSecurityToken(
                 issuer: config["JWT:ValidIss"],
                 audience: config["JWT:ValidAud"],
                 expires: DateTime.Now.AddHours(1),
                 claims: UserLoginClaims,
                 signingCredentials: signingCredentials
                 );

            ValidTokenDTO validToken = new ValidTokenDTO(LoginJWTToken);

            return validToken;
        }








    }
}
