using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.AccountDTOs;
using Clean_Architecture.core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Clean_Architecture.Application.responses;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;
using Org.BouncyCastle.Asn1.Ocsp;
using System;


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

          private async Task SendConfirmationEmail(string email, string callbackUrl)
    {
        var message = new Message(new string[] { email }, "Reset password token", callbackUrl, null);
        await _emailSender.SendEmailAsync(message);
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
            var user = await unitOfWork.UserRepository.FindByEmailAsync(resetPasswordDto.Email);
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
            var callbackUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}/api/account/reset-password?token={token}&email={user.Email}";

            var message = new Message(new string[] { user.Email }, "Reset password token", callbackUrl, null);
            await emailService.SendEmailAsync(message);

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
