﻿using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.InKindDonationDTOs;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Enums;
using Clean_Architecture.core.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace Clean_Architecture.Application.services
{
    public class InKindDonationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public InKindDonationService(IUnitOfWork unitOfWork, IMapper mapper,UserManager<ApplicationUser>userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<List<showInKindDonationDTO>> GetInKindDonation()
        {
            var inKindDonation = await unitOfWork.inKindDonationRepository.GetAllAsync();
            var inKindDonationsDtos = mapper.Map<List<showInKindDonationDTO>>(inKindDonation);

            foreach (var donation in inKindDonationsDtos)
            {
                var project = unitOfWork.projectRepository.Get(p => p.Id == donation.projectId);
                donation.ProjectName = project.Title;
                donation.projectImage = project.ImgUrl;
                var charity = unitOfWork.charities.Get(c => c.Id == donation.CharityId);
                donation.charityName = charity.Name;


                var donor = unitOfWork.donorRepository.Get(d => d.Id == donation.DonorId);
                donation.DonorName = donor.Name;
            }

            return inKindDonationsDtos;
        }


        public showInKindDonationDTO GetInKindDoationById(int id)
        {
            var inKindDonationByid = unitOfWork.inKindDonationRepository.Get(i => i.Id == id);
            return mapper.Map<showInKindDonationDTO>(inKindDonationByid);
        }

        public List<showInKindDonationDTO> GetInKindDonationByDonorId(string id)
        {
            List<InKindDonation> inKindDonations = unitOfWork.inKindDonationRepository.GetAll().Where(i => i.DonorId == id).ToList();

            List<showInKindDonationDTO> inKindDonationsDtos = mapper.Map<List<showInKindDonationDTO>>(inKindDonations);
            foreach (var donation in inKindDonationsDtos)
            {
                var project = unitOfWork.projectRepository.Get(p => p.Id == donation.projectId);
                donation.ProjectName = project.Title;
                donation.projectImage = project.ImgUrl;
                var charity = unitOfWork.charities.Get(c => c.Id == donation.CharityId);
                donation.charityName = charity.Name;
            }


            return inKindDonationsDtos;

        }

        public List<showInKindDonationDTO> GetInKindDonationByProjectId(int id)
        {
            List<InKindDonation> inKindDonations = unitOfWork.inKindDonationRepository.GetAll().Where(i => i.projectId == id).ToList();
            return mapper.Map<List<showInKindDonationDTO>>(inKindDonations);

        }

        public List<showInKindDonationDTO> GetInkindDonationByCharityId(string id)
        {
            List<InKindDonation> inKindDonations = unitOfWork.inKindDonationRepository.GetAll().Where(i => i.CharityId == id).ToList();

            List<showInKindDonationDTO> inKindDonationsDtos = mapper.Map<List<showInKindDonationDTO>>(inKindDonations);
            foreach (var donation in inKindDonationsDtos)
            {
                var project = unitOfWork.projectRepository.Get(p => p.Id == donation.projectId);
                donation.ProjectName = project.Title;
                donation.projectImage = project.ImgUrl;
                var charity = unitOfWork.charities.Get(c => c.Id == donation.CharityId);
                donation.charityName = charity.Name;
                var donor = unitOfWork.donorRepository.Get(d => d.Id == donation.DonorId);
                donation.DonorName = donor.Name;

            }


            return inKindDonationsDtos;

        }

        public void AddInKindDonation(addInKindDonationDTO addInKindDonationDTO)
        {
            var inKindDonation = mapper.Map<InKindDonation>(addInKindDonationDTO);
            unitOfWork.inKindDonationRepository.insert(inKindDonation);


            Project project = unitOfWork.projects.Get(p => p.Id == addInKindDonationDTO.projectId);


            var admin = userManager.Users.FirstOrDefault(u => u.accountType == AccountType.Admin);
            Donor donor = unitOfWork.donorRepository.Get(d => d.Id == addInKindDonationDTO.DonorId);
            if (admin != null)
            {
                // Add notification for the admin
                var notification = new Notification
                {
                    Message = $"New Inkind Donation from:{donor.Name}",
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    AdminId = admin.Id
                };

                unitOfWork.NotificationRepository.insert(notification);
               project.AmountRaised += addInKindDonationDTO.Quantity;
                if (project.AmountRaised >= project.FundingGoal)
                {
                    project.State = ProjectState.Compeleted;
                }
                else
                {
                    project.State = ProjectState.InProgress;
                }
                unitOfWork.Save();
            } }
        public void UpdateInKindDonation(int id, updateInKindDonationDTO updateInKindDonationDTO)
        {

            InKindDonation inKindDonation = unitOfWork.inKindDonationRepository.Get(i => i.Id == id);
            mapper.Map(updateInKindDonationDTO, inKindDonation);
            unitOfWork.inKindDonationRepository.update(inKindDonation);
            unitOfWork.Save();
        }

        public void DeleteInKindDonation(int id)
        {
            InKindDonation inKindDonation = unitOfWork.inKindDonationRepository.Get(i => i.Id == id);
            unitOfWork.inKindDonationRepository.delete(inKindDonation);
            unitOfWork.Save();
        }
    }
}
