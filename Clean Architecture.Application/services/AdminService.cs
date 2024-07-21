using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.NotificationDTOs;
using Clean_Architecture.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.services
{
    public class AdminService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public bool BlockCharity(int charityid)
        {
            Charity charity = unitOfWork.charities.Get(c => c.Id == charityid);
            if (charity == null)
            {

                return false;

            }
            else
            {
                charity.IsBlocked = true;
                unitOfWork.Save();
                return true;
            }
        }

        public bool UnBlockCharity(int charityid)
        {
            Charity charity = unitOfWork.charities.Get(c => c.Id == charityid);
            if (charity == null)
            {

                return false;

            }
            else
            {
                charity.IsBlocked = false;
                unitOfWork.Save();
                return true;
            }
        }


        public List<showNotificationDTO> GetAllNotification()
        {
            var notifications = unitOfWork.NotificationRepository.GetAll();
            var notificationDTOs = notifications.Select(notification => mapper.Map<showNotificationDTO>(notification)).ToList();
            return notificationDTOs;
        }


    }
}
