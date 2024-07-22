﻿using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.UsersDTO;
using Clean_Architecture.core.Enums;
using Clean_Architecture.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.services
{
    public class UserServices
    {
        private readonly IUnitOfWork unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }



        public List<ShowUsers>GetAllUsers()

        {

       List<ApplicationUser> users= unitOfWork.UserRepository.GetAll().ToList();
    
          List<  ShowUsers> showUsersList =new List<ShowUsers>(); 

            foreach (var user in users)
            {
                ShowUsers usersList = new ShowUsers();
                usersList.name = user.UserName;
                usersList.AccountType = user.accountType;
                usersList.email = user.Email;
                usersList.emailConfirmed = user.EmailConfirmed;


                if(user.accountType==AccountType.Donor)
                {
                    Donor donor = unitOfWork.donorRepository.Get(u =>u.Id==user.Id);
                    usersList.image = donor.ProfileImg;
                }
                else if(user.accountType== AccountType.Chatiry)
                {
                    Charity charity=unitOfWork.charities.Get(c=>user.Id==c.Id);
                    usersList.image= charity.ProfileImg;
                }
                else
                {

                }

               showUsersList.Add(usersList);

            }
            return showUsersList;           
        }
    }
}
