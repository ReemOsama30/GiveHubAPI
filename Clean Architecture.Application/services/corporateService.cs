using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.corporateDTOs;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.services
{
    public class corporateService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public corporateService(IMapper mapper,IUnitOfWork unitOfWork )
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

       
        public async Task<List<showCorporateDTO>> getAllCorporates()
        {

            var corprates=await unitOfWork.corporations.GetAllAsync();
        return mapper.Map<List<showCorporateDTO>>( corprates );
        
        }


        public void deleteCorporate(int id)
        {
            var corporate=unitOfWork.corporations.Get(c=>c.Id==id);
            unitOfWork.corporations.delete(corporate);
            unitOfWork.Save();
        }



        public showCorporateDTO getById(int id)
        {
       var corporate=unitOfWork.corporations.Get(c=>c.Id==id);
       return mapper.Map<showCorporateDTO>( corporate );
        
        }
        public void addCorporate(addCorporateDTO addCorporateDTO)
        {
            var corporate = mapper.Map<Corporate>(addCorporateDTO);
            corporate.IsDeleted = false;
          //  corporate.ProfileImg= File.ReadAllBytes(addCorporateDTO.ProfileImgURL);
            unitOfWork.corporations.insert(corporate);
            unitOfWork.Save();


        }


        public void updateCoroprate(int id, updateCorporateDTO NewCorporate)
        {
            Corporate existingCorporate = unitOfWork.corporations.Get(c => c.Id == id);
           //will be fixed laterrrrrr
            
            string accountId = existingCorporate.ApplicationUserId;
            existingCorporate=mapper.Map<Corporate>(NewCorporate);
            existingCorporate.ApplicationUserId = accountId;
           // existingCorporate.ProfileImg = File.ReadAllBytes(NewCorporate.ProfileImgURL);
            unitOfWork.corporations.update(existingCorporate);
            unitOfWork.Save();
        }

    }
}
