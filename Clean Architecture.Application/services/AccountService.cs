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
using Microsoft.AspNetCore.Mvc;


namespace Clean_Architecture.Application.services
{
    public class AccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config, SignInManager<ApplicationUser> signInManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.config = config;
            this.signInManager = signInManager;
        }


        public async Task<IdentityResult> RegisterUserAsync(UserRegisterDTO userDTO)
        {
            //ApplicationUser user = mapper.Map<ApplicationUser>(userDTO)

            ApplicationUser user = new ApplicationUser()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                AccountType = userDTO.AccountType,
            };




            var result = await unitOfWork.UserRepository.CreateUserAsync(user, userDTO.Password);
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
        public async Task<bool> CheckPasswordAsync(ApplicationUser UserFromDB, string PasswordFromDTO)
        {
            bool result = await unitOfWork.UserRepository.CheckPasswordAsync(UserFromDB, PasswordFromDTO);
            return result;

        }

        private async Task<List<Claim>> CreateClaims(ApplicationUser UserFromDB)
        {
            List<Claim> UserLoginClaims = new List<Claim>();
            UserLoginClaims.Add(new Claim(ClaimTypes.Name, UserFromDB.UserName));
            UserLoginClaims.Add(new Claim(ClaimTypes.NameIdentifier, UserFromDB.Id));
            UserLoginClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

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




        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            ApplicationUser user = await unitOfWork.UserRepository.FindByEmailAsync(email);
            return user;
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



    }
}
