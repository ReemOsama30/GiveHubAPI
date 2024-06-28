using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.Application.DTOs.charityDTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.services
{
    public class BadgeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BadgeService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public void Add(AddBadgeDTO addBadgeDTO)
        {
            Badge badge = _mapper.Map<Badge>(addBadgeDTO);


            string UploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "badgeImg");
            string imageName = Guid.NewGuid().ToString() + "-" + addBadgeDTO.Icon.FileName;
            string filePath = Path.Combine(UploadPath, imageName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                addBadgeDTO.Icon.CopyTo(fileStream);
            }

            badge.Icon = $"/charityImg/{imageName}";
           

            _unitOfWork.Badges.insert(badge);
            _unitOfWork.Save();
        }

        // Method to get all badges (constant badge definitions)
        public async Task<List<ShowBadgeDTO>> GetBadges()
        {
            var badges = await _unitOfWork.Badges.GetAllAsync();
            return _mapper.Map<List<ShowBadgeDTO>>(badges);
        }

        // Method to get a badge by its ID (constant badge definition)
        public ShowBadgeDTO GetBadgeById(int id)
        {
            var badge = _unitOfWork.Badges.Get(b => b.Id == id);
            return _mapper.Map<ShowBadgeDTO>(badge);
        }

        // Method to delete a badge (constant badge definition)
        public void DeleteBadge(int id)
        {
            Badge badge = _unitOfWork.Badges.Get(b => b.Id == id);
            _unitOfWork.Badges.delete(badge);
            _unitOfWork.Save();
        }

        // Method to update a badge (constant badge definition)
        public void UpdateBadge(int id, UpdateBadgeDTO newBadge)
        {
            Badge existingBadge = _unitOfWork.Badges.Get(b => b.Id == id);
            _mapper.Map(newBadge, existingBadge);
            _unitOfWork.Badges.update(existingBadge);
            _unitOfWork.Save();
        }

        // Method to award a badge to a donor, charity, or corporate
        //public void AwardBadgeToEntity(AwardBadgeDTO awardBadgeDTO)
        //{
        //    var awardedBadge = _mapper.Map<AwardedBadge>(awardBadgeDTO);
        //    awardedBadge.DateReceived = DateTime.Now;
        //    awardedBadge.IsDeleted = false;
        //    _unitOfWork.AwardedBadges.Insert(awardedBadge);
        //    _unitOfWork.Save();
        //}

        //// Method to get all awarded badges for a specific donor
        //public List<ShowAwardedBadgeDTO> GetBadgesByDonorId(int donorId)
        //{
        //    var awardedBadges = _unitOfWork.AwardedBadges.GetAll().Where(ab => ab.DonorId == donorId).ToList();
        //    return _mapper.Map<List<ShowAwardedBadgeDTO>>(awardedBadges);
        //}

        //// Method to get all awarded badges for a specific charity
        //public List<ShowAwardedBadgeDTO> GetBadgesByCharityId(int charityId)
        //{
        //    var awardedBadges = _unitOfWork.AwardedBadges.GetAll().Where(ab => ab.CharityId == charityId).ToList();
        //    return _mapper.Map<List<ShowAwardedBadgeDTO>>(awardedBadges);
        //}

        //// Method to get all awarded badges for a specific corporate
        //public List<ShowAwardedBadgeDTO> GetBadgesByCorporateId(int corporateId)
        //{
        //    var awardedBadges = _unitOfWork.AwardedBadges.GetAll().Where(ab => ab.CorporateId == corporateId).ToList();
        //    return _mapper.Map<List<ShowAwardedBadgeDTO>>(awardedBadges);
        //}
    }
}
