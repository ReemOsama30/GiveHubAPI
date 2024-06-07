using AutoMapper;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.core.Interfaces;
using charityPulse.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.services
{
    public class AdvertismentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AdvertismentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<AdvertismentDTO>> GetAdvertisments()
        {
            var advertisments = await unitOfWork.advertisments.GetAllAsync();
            return mapper.Map<List<AdvertismentDTO>>(advertisments);
        }

        public AdvertismentDTO GetAdvertismentById(int id)
        {
            var advertisment = unitOfWork.advertisments.Get(i => i.Id == id);
            return mapper.Map<AdvertismentDTO>(advertisment);
        }

        public void AddAdvertisment(AdvertismentDTO advertismentDTO)
        {
            var advertisment = mapper.Map<Advertisment>(advertismentDTO);
            advertisment.IsDeleted = false;
            unitOfWork.advertisments.insert(advertisment);
            unitOfWork.Save();
        }

        public void DeleteAdvertisment(int id)
        {
            Advertisment advertisment = unitOfWork.advertisments.Get(p => p.Id == id);
            unitOfWork.advertisments.delete(advertisment);
            unitOfWork.Save();
        }

        public void updateAdvertisment(AdvertismentDTO new_Advertisment)
        {
            Advertisment advertisment = mapper.Map<Advertisment>(new_Advertisment);

            unitOfWork.advertisments.update(advertisment);
            unitOfWork.Save();
        }


    }
}
