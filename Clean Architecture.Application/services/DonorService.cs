﻿using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.DonorDTOs;
using Clean_Architecture.Application.DTOs.NotificationDTOs;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Clean_Architecture.Application.services
{
    public class DonorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DonorService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<showDonorDTO>> GetDonors()
        {
            var donors = await unitOfWork.donorRepository.GetAllAsync();
            return mapper.Map<List<showDonorDTO>>(donors);
        }
        public showDonorDTO GetDonorById(string id)
        {
            var donor = unitOfWork.donorRepository.Get(i => i.Id == id);
            return mapper.Map<showDonorDTO>(donor);
        }
        public async Task<List<showDonorWithBadgeDTO>> GetDonorsWithBadges()
        {
            var donors = await unitOfWork.donorRepository.GetAllDonorWithBadgeAsync();
            return mapper.Map<List<showDonorWithBadgeDTO>>(donors);
        }

        public void AddDonor(addDonorDTO addDonorDTO)
        {

            var donor = mapper.Map<Donor>(addDonorDTO);

            string UploadPath = Path.Combine(webHostEnvironment.WebRootPath, "donorImg");
            string imageName = Guid.NewGuid().ToString() + "-" + addDonorDTO.Img.FileName;
            string filePath = Path.Combine(UploadPath, imageName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                addDonorDTO.Img.CopyTo(fileStream);
            }

            donor.ProfileImg = $"/donorImg/{imageName}";
            unitOfWork.donorRepository.insert(donor);
            unitOfWork.Save();
           
        }


        /// <summary>
        //need to be fixed later
        /// </summary>
        /// <param name="updateDonorDTO"></param>
        public void UpdateDonor(updateDonorDTO updateDonorDTO)
        {
            Donor donor = mapper.Map<Donor>(updateDonorDTO);

            // donor.ProfileImg = File.ReadAllBytes(updateDonorDTO.img);
            donor.Id = "439213c3-e1c8-4fc5-a601-9d441a657dbd";
            unitOfWork.donorRepository.update(donor);
            unitOfWork.Save();

        }
        public void DeleteDonor(string id)
        {
            Donor donor = unitOfWork.donorRepository.Get(d => d.Id == id);
            unitOfWork.donorRepository.delete(donor);
            unitOfWork.Save();
        }



        public string getAccountIdBYdonorName(string donorname)
        {
            ApplicationUser user = unitOfWork.UserRepository.Get(c => c.UserName == donorname);
            return user?.Id;
        }



   
        public donorDetailsDTO getDonorDetails(string userId)
        {
            var userDetails = unitOfWork.UserRepository.Get(u => u.Id == userId);
            donorDetailsDTO donorDetails = new donorDetailsDTO();
            donorDetails.userName = userDetails.UserName;
            donorDetails.email = userDetails.Email;
            return donorDetails;

        }


        public List<DonorsProfilsDTO> GetDonorProfile()
        {
            var donorProfile=unitOfWork.donorRepository.GetAll();
            var donorProfileDto = donorProfile.Select(notification => mapper.Map<DonorsProfilsDTO>(notification)).ToList();
        return donorProfileDto;
        }

    }
}
