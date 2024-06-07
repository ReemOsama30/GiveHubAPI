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
using System.Text;
using System.Threading.Tasks;

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

        public void AddUser (UserRegisterDTO registerDTO)
        {
            
            //var User = mapper.Map<>(DTO);
            //User.IsDeleted = false;
            //unitOfWork..insert(User);
            //unitOfWork.save();
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegisterDTO userDTO)
        {
            //ApplicationUser user = mapper.Map<ApplicationUser>(userDTO
            //
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
                await unitOfWork.CompleteAsync();
            }
            return result;
        }

    }
}
    