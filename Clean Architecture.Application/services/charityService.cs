using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.charityDTOs;
using Clean_Architecture.core.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Clean_Architecture.Application.services
{
    public class charityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public charityService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }
    

        public string getAccountIdBYcharityName(string charityName)
        {
            Charity user = unitOfWork.charities.Get(c => c.Name == charityName);
            return user?.Id;
        }
        public async Task<List<showCharityDTO>> getCharities()
        {
            var charities = await unitOfWork.charities.GetAllAsync();
            List<showCharityDTO> showCharityDTOs = mapper.Map<List<showCharityDTO>>(charities);
            return showCharityDTOs;
        }
        public showCharityDTO getCharityById(string id)
        {
            Charity charity = unitOfWork.charities.Get(c => c.Id == id);
            showCharityDTO charityDTO = mapper.Map<showCharityDTO>(charity);
            return charityDTO;
        }


        public string getCharityIdByProjectID(int id)
        {
            Project project = unitOfWork.projectRepository.Get(p => p.Id == id);
            Charity charity = unitOfWork.charities.Get(c => c.Id == project.CharityId);
           
            return charity.Id;
        }





        public showCharityDTO getCharitiesByAccountId(string id)
        {
            Charity charity = unitOfWork.charities.Get(c => c.Id == id);
            showCharityDTO charitiesDTOs = mapper.Map<showCharityDTO>(charity);
            return charitiesDTOs;
        }
        public void updateCharity(string id, updateCharityDTO newCharity)
        {
            Charity existingCharity = unitOfWork.charities.Get(c => c. Id == id);
            string accountId = existingCharity.Id;
            existingCharity.Description = newCharity.Description;
            existingCharity.WebsiteUrl = newCharity.WebsiteUrl;
            existingCharity.Id = accountId;
            unitOfWork.charities.update(existingCharity);
            var charity = unitOfWork.charities.Get(c => c.Id == id);
            unitOfWork.charities.update(charity);
            unitOfWork.Save();

            if (charity != null)
            {
                mapper.Map(newCharity, charity);
                string UploadPath = Path.Combine(webHostEnvironment.WebRootPath, "charityImg");
                string imageName = Guid.NewGuid().ToString() + "-" + newCharity.ImgUrl.FileName;
                string filePath = Path.Combine(UploadPath, imageName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    newCharity.ImgUrl.CopyTo(fileStream);
                }
                charity.ProfileImg = $"/charityImg/{imageName}";
                unitOfWork.charities.update(charity);
                unitOfWork.Save();
            }
        }
        public void deleteCharity(string id)
        {
            Charity charity = unitOfWork.charities.Get(c => c.Id == id);
            unitOfWork.charities.delete(charity);
            unitOfWork.Save();
        }
    }
}
