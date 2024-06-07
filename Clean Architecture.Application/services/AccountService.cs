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


namespace Clean_Architecture.Application.services
{
    public class AccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

      
        public async Task<IdentityResult> RegisterUserAsync(UserRegisterDTO userDTO)
        {
            //ApplicationUser user = mapper.Map<ApplicationUser>(userDTO)
            
            ApplicationUser user = new ApplicationUser()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                AccountType=userDTO.AccountType,
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

        public async void GenerateJWTtoken(ApplicationUser UserFromDB)
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

            var SignKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes("hello"));

            SigningCredentials signingCredentials =
                new SigningCredentials(SignKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken LoginJWTToken = new JwtSecurityToken(
                issuer: "http://localhost:5026/",
                audience: "http://localhost:4200",
                claims: UserLoginClaims,
                expires: DateTime.Now.AddHours(1)

                );
        }

    }
}
        