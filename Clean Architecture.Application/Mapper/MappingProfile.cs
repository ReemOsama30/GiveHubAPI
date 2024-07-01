using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.advertismentDTO;
using Clean_Architecture.Application.DTOs.AwardedBadgeDTOs;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.Application.DTOs.CategoryDTOs;
using Clean_Architecture.Application.DTOs.charityDTOs;
using Clean_Architecture.Application.DTOs.corporateDTOs;
using Clean_Architecture.Application.DTOs.DonationReportDTOs;
using Clean_Architecture.Application.DTOs.DonorDTOs;
using Clean_Architecture.Application.DTOs.InKindDonationDTOs;
using Clean_Architecture.Application.DTOs.MoneyDonationDTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.Application.DTOs.ReviewsDTOs;
using Clean_Architecture.core.Entities;




namespace Clean_Architecture.Application.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            // Project Mappings
            CreateMap<addProjectDTO, Project>();
            CreateMap<Project, showprojectDTO>();
            CreateMap<updateProjectDTO, Project>();

            // Charity Mappings
            CreateMap<addCharityDTO, Charity>();
            CreateMap<Charity, showCharityDTO>();
            CreateMap<showCharityDTO, Charity>();
            CreateMap<updateCharityDTO, Charity>();

            // Advertisement Mappings
            CreateMap<AdvertismentDTO, Advertisment>();
            CreateMap<Advertisment, AdvertismentDTO>();
            CreateMap<UpdateAsdvertismentDTO, Advertisment>();
            CreateMap<Advertisment, UpdateAsdvertismentDTO>();

            // Donation Report Mappings
            CreateMap<donationReportDTOWithProject, DonationReport>();
            CreateMap<DonationReport, donationReportDTOWithProject>();
            CreateMap<updateDonationReportDTO, DonationReport>();
            CreateMap<DonationReport, updateDonationReportDTO>();
            CreateMap<addDonationReportDTO, DonationReport>();
            CreateMap<DonationReport, addDonationReportDTO>();

            // Review Mappings
            CreateMap<Review, ReviewDTOWithDoner>();
            CreateMap<ReviewDTOWithDoner, Review>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();
            //CreateMap<Review, ReviewDTO>()
            //   .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Donor.ApplicationUserId)); 


            // Corporate Mappings
            CreateMap<Corporate, showCorporateDTO>();
            CreateMap<updateCorporateDTO, Corporate>();
            CreateMap<showCorporateDTO, Corporate>();


            // Badge Mappings
            CreateMap<AddBadgeDTO, Badge>();
            CreateMap<UpdateBadgeDTO, Badge>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Badge, ShowBadgeDTO>();

            CreateMap<AwardBadgeDTO, AwardedBadge>().ReverseMap();
            //CreateMap<AwardedBadge, ShowAwardedBadgeDTO>()
            //    .ForMember(dest => dest.BadgeName, opt => opt.MapFrom(src => src.Badge.Name))
            //    .ForMember(dest => dest.BadgeDescription, opt => opt.MapFrom(src => src.Badge.Description));

            //CreateMap<AddBadgeDTO, Badge>();
            //.ForMember(dest => dest.Icon, opt => opt.MapFrom(src => ConvertIconToBytes(src.Icon)));
            //CreateMap<UpdateBadgeDTO, Badge>()
            // .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => ConvertIconToBytes(src.Icon)));


            // Money Donation Mappings
            CreateMap<showMoneyDonationDTO, MoneyDonation>();
            CreateMap<MoneyDonation, showMoneyDonationDTO>();
            CreateMap<addMoneyDonationDTO, MoneyDonation>();
            CreateMap<MoneyDonation, addMoneyDonationDTO>();
            CreateMap<updateMoneyDonationDTO, MoneyDonation>();
            CreateMap<MoneyDonation, updateMoneyDonationDTO>();

            // In-Kind Donation Mappings
            CreateMap<showInKindDonationDTO, InKindDonation>();
            CreateMap<InKindDonation, showInKindDonationDTO>();
            CreateMap<addInKindDonationDTO, InKindDonation>();
            CreateMap<InKindDonation, addInKindDonationDTO>();
            CreateMap<updateInKindDonationDTO, InKindDonation>();
            CreateMap<InKindDonation, updateInKindDonationDTO>();

            // Donor Mappings
            CreateMap<addDonorDTO, Donor>();
            CreateMap<Donor, addDonorDTO>();
            CreateMap<showDonorDTO, Donor>();
            CreateMap<Donor, showDonorDTO>();
            CreateMap<showDonorWithBadgeDTO, Donor>();
            CreateMap<Donor, showDonorWithBadgeDTO>();
            // .ForMember(dest => dest.BadgeName, opt => opt.MapFrom(src => src.Badges.Select(b => b.Name).ToList()));
            CreateMap<updateDonorDTO, Donor>();
            CreateMap<Donor, updateDonorDTO>();

            // Category Mappings
            CreateMap<showCategoriesDTO, Category>();
            CreateMap<Category, showCategoriesDTO>();


        }
        private byte[] ConvertIconToBytes(string iconPath)
        {
            return File.Exists(iconPath) ? File.ReadAllBytes(iconPath) : null;

           
        }

    }
}
