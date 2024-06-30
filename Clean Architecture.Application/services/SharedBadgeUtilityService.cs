using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.AwardedBadgeDTOs;
using Clean_Architecture.Application.DTOs.DonationDTOs;
using Clean_Architecture.Application.DTOs.MoneyDonationDTOs;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;


namespace Clean_Architecture.Infrastructure.Repositories
{
    public class SharedBadgeUtilityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SharedBadgeUtilityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AwardBadgeToEntity(AwardBadgeDTO awardBadgeDTO)
        {
            AwardedBadge awardedBadge = _mapper.Map<AwardedBadge>(awardBadgeDTO);

            awardedBadge.DateReceived = DateTime.Now;
            awardedBadge.IsDeleted = false;

            _unitOfWork.AwardedBadges.insert(awardedBadge);
            _unitOfWork.Save();
        }

        private GeneralDonationDTO MapMoneyDonation(addMoneyDonationDTO addMoneyDonationDTO)
        {
            GeneralDonationDTO generalDonation = new GeneralDonationDTO()
            {
                DonationDate = addMoneyDonationDTO.DonationDate,
                DonorId = addMoneyDonationDTO.DonorId,
                CharityId = addMoneyDonationDTO.CharityId,
                projectId = addMoneyDonationDTO.projectId,
                Amount = addMoneyDonationDTO.Amount

            };
            return generalDonation;
        }

        private AwardBadgeDTO GenerateAwardedBadge(int donorId, string badgeName)
        {
            int badgeId = _unitOfWork.Badges.Get(b => b.Name == $"{badgeName}").Id;

            AwardBadgeDTO GeneratedBadge = new()
            {
                BadgeId = badgeId,
                DonorId = donorId
            };

            return GeneratedBadge;

        }


        private bool IsFirstDonation(int donorId)
        {
            return _unitOfWork.donorRepository.Get(d => d.Id == donorId).Donations.Count() == 1;
        }
        private bool Is10thDonation(int donorId)
        {
            return _unitOfWork.donorRepository.Get(d => d.Id == donorId).Donations.Count() == 10;
        }
        private bool Is50thDonation(int donorId)
        {
            return _unitOfWork.donorRepository.Get(d => d.Id == donorId).Donations.Count() == 50;
        }
        private bool IsGenerousDonor(decimal? amount)
        {
            return amount >= 30000;
        }
        private bool IsMultipleCausesSupporter(int donorId)
        {
            bool AlreadyEarnedBadge = _unitOfWork.donorRepository.HasMultipleCausesSupporterBadge(donorId);

            if (AlreadyEarnedBadge)
            {
                return false;
            }

            var CauseCount = _unitOfWork.donorRepository.GetAllDistinctDonationCategories(donorId);

            return CauseCount >= 4;
        }

        public void CheckDonationToAwardBadges(addMoneyDonationDTO addMoneyDonationDTO)

        {
            var donation = MapMoneyDonation(addMoneyDonationDTO);

            var donorId = donation.DonorId;


            if (IsFirstDonation(donorId))
            {
                AwardBadgeToEntity(GenerateAwardedBadge(donorId, "First Donation"));
            }
            else
            {
                if (Is10thDonation(donorId))
                {
                    AwardBadgeToEntity(GenerateAwardedBadge(donorId, "First Milestone Donor"));
                }

                if (Is50thDonation(donorId))
                {
                    AwardBadgeToEntity(GenerateAwardedBadge(donorId, "Second Milestone Donor"));
                }
            }

            if (IsGenerousDonor(donation.Amount))
            {
                AwardBadgeToEntity(GenerateAwardedBadge(donorId, "Generous Giver"));
            }

            if (IsMultipleCausesSupporter(donorId))
            {
                AwardBadgeToEntity(GenerateAwardedBadge(donorId, "Supporter of Multiple Causes"));
            }



            // Check for Top Donor Badge (this might need more complex logic, e.g., calculating top donors of the month)
            // For simplicity, we'll assume you have a method to get top donors
            //if (IsTopDonor(donor))
            //{
            //    AwardBadge(donorId, BadgeType.TopDonor);
            //}

            _unitOfWork.Save();
        }
    }
}
