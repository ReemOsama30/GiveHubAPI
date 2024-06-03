using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.charityDTOs;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.services
{
    public class charityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public charityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void addCharity(addCharityDTO CharityDTO)
        {
            var charity = mapper.Map<Charity>(CharityDTO);
            charity.ProfileImg = File.ReadAllBytes(CharityDTO.ImgUrl);
            //need to be changed after register is done
            charity.ApplicationUserId = "e43201d5-204e-4b66-80e8-f6cd8999083f";
            unitOfWork.charities.insert(charity);
            unitOfWork.save();

        }
        public async Task<List<showCharityDTO>> getCharities()
        {
            var charities = await unitOfWork.charities.GetAllAsync();
            List<showCharityDTO> showCharityDTOs = mapper.Map<List<showCharityDTO>>(charities);
            return showCharityDTOs;
        }
        public showCharityDTO getCharityById(int id)
        {
            Charity charity = unitOfWork.charities.Get(c => c.Id == id);
            showCharityDTO charityDTO = mapper.Map<showCharityDTO>(charity);
            return charityDTO;
        }
        public showCharityDTO getCharitiesByAccountId(string id)
        {
            Charity charity = unitOfWork.charities.Get(c => c.ApplicationUserId == id);
            showCharityDTO charitiesDTOs = mapper.Map<showCharityDTO>(charity);
            return charitiesDTOs;
        }
        public void updateCharity(int id, updateCharityDTO newCharity)
        {
            Charity existingCharity = unitOfWork.charities.Get(c => c.Id == id);
            string accountId = existingCharity.ApplicationUserId;
            existingCharity.Description = newCharity.Description;
            existingCharity.WebsiteUrl = newCharity.WebsiteUrl;
            existingCharity.ProfileImg = File.ReadAllBytes(newCharity.ImgUrl);
            existingCharity.ApplicationUserId = accountId;
            unitOfWork.charities.update(existingCharity);
            unitOfWork.save();
        }
        public void deleteCharity(int id)
        {
            Charity charity = unitOfWork.charities.Get(c => c.Id == id);
            unitOfWork.charities.delete(charity);
            unitOfWork.save();
        }
    }
}
