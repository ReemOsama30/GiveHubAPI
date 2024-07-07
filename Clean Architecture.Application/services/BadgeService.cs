using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.AwardedBadgeDTOs;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.Application.DTOs.DonationDTOs;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Hosting;
using Clean_Architecture.Infrastructure.Repositories;

namespace Clean_Architecture.Application.services
{
    public class BadgeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly SharedBadgeUtilityService _badgeUtilityService;

        public BadgeService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment , SharedBadgeUtilityService sharedBadgeUtilityService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _badgeUtilityService = sharedBadgeUtilityService;
        }

        public void AddBadge(AddBadgeDTO addBadgeDTO)
        {
            Badge badge = _mapper.Map<Badge>(addBadgeDTO);


            string UploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "BadgeImg");
            string imageName = Guid.NewGuid().ToString() + "-" + addBadgeDTO.Icon.FileName;
            string filePath = Path.Combine(UploadPath, imageName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                addBadgeDTO.Icon.CopyTo(fileStream);
            }

            badge.Icon = $"/BadgeImg/{imageName}";
           

            _unitOfWork.Badges.insert(badge);
            _unitOfWork.Save();
        }

        public async Task<List<ShowBadgeDTO>> GetBadges()
        {
            IEnumerable<Badge> badges = await _unitOfWork.Badges.GetAllAsync();
            return _mapper.Map<List<ShowBadgeDTO>>(badges);
        }

        public ShowBadgeDTO GetBadgeById(int id)

        {
            Badge badge = _unitOfWork.Badges.Get(b => b.Id == id);
            return _mapper.Map<ShowBadgeDTO>(badge);
        }

        public void DeleteBadge(int id)
        {
            Badge badge = _unitOfWork.Badges.Get(b => b.Id == id);
            _unitOfWork.Badges.delete(badge);
            _unitOfWork.Save();
        }

        public void UpdateBadge(int id, UpdateBadgeDTO newBadge)
        {
            Badge existingBadge = _unitOfWork.Badges.Get(b => b.Id == id);


            _mapper.Map(newBadge, existingBadge);


            _unitOfWork.Badges.update(existingBadge);
            _unitOfWork.Save();
        }

        public void AwardBadgeToEntity(AwardBadgeDTO awardBadgeDTO)
        {
            _badgeUtilityService.AwardBadgeToEntity(awardBadgeDTO);
        }


       


    }
}
