using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.AwardedBadgeDTOs;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.services
{
    public class AwardedBadgeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AwardedBadgeService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public void Add(AwardBadgeDTO addAwardBadgeDTO)
        {
            AwardedBadge awardbadge = _mapper.Map<AwardedBadge>(addAwardBadgeDTO);
            _unitOfWork.AwardedBadges.insert(awardbadge);
            _unitOfWork.Save();
        }
        public async Task<List<AwardBadgeDTO>> Get()
        {
            IEnumerable<AwardedBadge> Awardbadges = await _unitOfWork.AwardedBadges.GetAllAsync();
            return _mapper.Map<List<AwardBadgeDTO>>(Awardbadges);
        }

        public void Delete(int id)
        {
            AwardedBadge awardedBadge = _unitOfWork.AwardedBadges.Get(b => b.Id == id);
            _unitOfWork.AwardedBadges.delete(awardedBadge);
            _unitOfWork.Save();
        }


        public void Update(int id, AwardBadgeDTO newBadge)
        {
            AwardedBadge existingawardBadge = _unitOfWork.AwardedBadges.Get(b => b.Id == id);


            _mapper.Map(newBadge, existingawardBadge);


            _unitOfWork.AwardedBadges.update(existingawardBadge);
            _unitOfWork.Save();
        }

        public AwardBadgeDTO GetById(int id)

        {
            AwardedBadge awardedBadge = _unitOfWork.AwardedBadges.Get(b => b.Id == id);
            return _mapper.Map<AwardBadgeDTO>(awardedBadge);
        }


        public List<ShowBadgeDTO> GetByDonorId(int donorId) {

       List<AwardedBadge >awardedBadge = _unitOfWork.AwardedBadges.GetAll().Where(d=>d.DonorId==donorId).ToList();
List<ShowBadgeDTO>showBadgeDTOs = new List<ShowBadgeDTO>();

              foreach(var awardbadge in awardedBadge)
            {
                Badge badge = _unitOfWork.Badges.Get(b=>b.Id==awardbadge.BadgeId);
                ShowBadgeDTO showbadge =new ShowBadgeDTO();
                showbadge.Name=badge.Name;
                showbadge.Description=badge.Description;
                showbadge.Icon=badge.Icon;

                showBadgeDTOs.Add(showbadge);  






            }



            return showBadgeDTOs;


        }

    }
}
