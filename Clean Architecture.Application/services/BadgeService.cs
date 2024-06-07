using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.Application.DTOs.charityDTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.services
{
    public class BadgeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BadgeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void AddBadge(AddBadgeDTO addBadgeDTO)
        {
            var badge = mapper.Map<Badge>(addBadgeDTO);
            badge.IsDeleted = false;
            unitOfWork.badgs.insert(badge);
            unitOfWork.save();
        }

        public async Task<List<ShowBadgeDTO>> GetBadgs()
        {
            var padgs = await unitOfWork.badgs.GetAllAsync();
            return mapper.Map<List<ShowBadgeDTO>>(padgs);
        }

        public ShowBadgeDTO GetBadgeById(int id)
        {
            var badge = unitOfWork.badgs.Get(b => b.Id == id);
            return mapper.Map<ShowBadgeDTO>(badge);
        }

        public void DeleteBadge(int id)
        {
            Badge badge = unitOfWork.badgs.Get(b => b.Id == id);
            unitOfWork.badgs.delete(badge);
            unitOfWork.save();
        }
        public void UpdateBadge(int id, UpdateBadgeDTO newBadge)
        {
            Badge existingBadge = unitOfWork.badgs.Get(b => b.Id == id);
            mapper.Map(newBadge, existingBadge);
            unitOfWork.badgs.update(existingBadge);
            unitOfWork.save();


        }
         public List<Badge> GetBadgesByDonnerId(int id)
         {
            List<Badge> badges = unitOfWork.badgs.GetAll().Where(b => b.DonorId == id).ToList();
            return badges;
        }

        public List<Badge> GetBadgesByCharityId(int id)
        {
            List<Badge> badges = unitOfWork.badgs.GetAll().Where(b => b.CharityId == id).ToList();
            return badges;
        }
           

        public List<Badge> GetBadgesByCorporateId(int id)
        {
            List<Badge> badges = unitOfWork.badgs.GetAll().Where(b => b.CorporateId == id).ToList();
            return badges;
        }
    }
}
