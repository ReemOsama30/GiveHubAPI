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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clean_Architecture.Application.Models;

namespace Clean_Architecture.Application.Services
{
    public class AccountService : IAccountService
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
            var user = mapper.Map<ApplicationUser>(userDTO);

            var result = await unitOfWork.UserRepository.CreateUserAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                await unitOfWork.SaveAsync();
                var token = await unitOfWork.UserRepository.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}/api/account/confirm-email?token={token}&email={user.Email}";
                await SendConfirmationEmail(userDTO.Email, callbackUrl);
            }
            return result;
        }

        private async Task SendConfirmationEmail(string email, string callbackUrl)
        {
            var message = new Message(new string[] { email }, "Email Confirmation", callbackUrl, null);
            await emailService.SendEmailAsync(message);
        }

        public async Task<ApplicationUser> FindByNameAsync(UserLogInDTO userDTO)
        {
            return await unitOfWork.UserRepository.FindByNameAsync(userDTO.UserName);
        }

        public async Task<ApplicationUser> FindByIdAsync(string userID)
        {
            return await unitOfWork.UserRepository.FindByIdAsync(userID);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await unitOfWork.UserRepository.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            return await unitOfWork.UserRepository.ConfirmEmailAsync(user, token);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await unitOfWork.UserRepository.CheckPasswordAsync(user, password);
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

        private async Task<List<Claim>> CreateClaims(ApplicationUser user)
        {
            var userLoginClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("AccountType", user.AccountType)
            };

            IList<string> roles = await unitOfWork.UserRepository.GetRolesAsync(user);
            foreach (string role in roles)
            {
                userLoginClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            return userLoginClaims;
        }

        private async Task<SigningCredentials> CreateSigningCredentials()
        {
            var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecritKey"]));
            return new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);
        }

        public async Task<ValidTokenDTO> GenerateJWTtoken(ApplicationUser user)
        {
            var userLoginClaims = await CreateClaims(user);
            var signingCredentials = await CreateSigningCredentials();

            var loginJWTToken = new JwtSecurityToken(
                issuer: config["JWT:ValidIss"],
                audience: config["JWT:ValidAud"],
                expires: DateTime.Now.AddHours(1),
                claims: userLoginClaims,
                signingCredentials: signingCredentials
            );

            return new ValidTokenDTO(loginJWTToken);
        }
    }
}
