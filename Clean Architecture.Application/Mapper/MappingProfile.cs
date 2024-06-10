using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.advertismentDTO;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.Application.DTOs.charityDTOs;
using Clean_Architecture.Application.DTOs.corporateDTOs;
using Clean_Architecture.Application.DTOs.DonationReportDTOs;
using Clean_Architecture.Application.DTOs.DonorDTOs;
using Clean_Architecture.Application.DTOs.MoneyDonationDTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.Application.DTOs.ReviewsDTOs;

using Clean_Architecture.Application.DTOs.DonationReportDTOs;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.Application.DTOs.AccountDTOs;
using Clean_Architecture.Application.DTOs.InKindDonationDTOs;




namespace Clean_Architecture.Application.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<addProjectDTO, Project>();
            CreateMap<Project, showprojectDTO>();
            CreateMap<updateProjectDTO, Project>();


            CreateMap<addCharityDTO, Charity>();
            CreateMap<Charity, showCharityDTO>();
            CreateMap<showCharityDTO, Charity>();
            CreateMap<updateCharityDTO, Charity>();


            CreateMap<AdvertismentDTO, Advertisment>();
            CreateMap<Advertisment, AdvertismentDTO>();
            CreateMap<Advertisment, UpdateAsdvertismentDTO>();
            CreateMap<UpdateAsdvertismentDTO, Advertisment>();



            CreateMap<donationReportDTOWithProject, DonationReport>();
            CreateMap<DonationReport, donationReportDTOWithProject>();
            CreateMap<updateDonationReportDTO, DonationReport>();
            CreateMap<DonationReport, updateDonationReportDTO>();
            CreateMap<addDonationReportDTO, DonationReport>();
            CreateMap<DonationReport, addDonationReportDTO>();


            CreateMap<Review, ReviewDTOWithDoner>();
            CreateMap<ReviewDTOWithDoner, Review>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();



            //CreateMap<Review, ReviewDTO>()
            //   .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Donor.ApplicationUserId)); 

            CreateMap<Corporate, showCorporateDTO>();
            CreateMap<updateCorporateDTO, Corporate>();
            CreateMap<showCorporateDTO, Corporate>();



            CreateMap<AddBadgeDTO, Badge>();
            CreateMap<Badge, ShowBadgeDTO>();
            CreateMap<AddBadgeDTO, Badge>()
            .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => ConvertIconToBytes(src.Icon)));
            CreateMap<UpdateBadgeDTO, Badge>()
             .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => ConvertIconToBytes(src.Icon)));


            CreateMap<showMoneyDonationDTO, MoneyDonation>();
            CreateMap<MoneyDonation, showMoneyDonationDTO>();

            CreateMap<addMoneyDonationDTO, MoneyDonation>();
            CreateMap<MoneyDonation, addMoneyDonationDTO>();

            CreateMap<updateMoneyDonationDTO, MoneyDonation>();
            CreateMap<MoneyDonation, updateMoneyDonationDTO>();

            CreateMap<showInKindDonationDTO, InKindDonation>();
            CreateMap<InKindDonation,showInKindDonationDTO>();

            CreateMap<addInKindDonationDTO, InKindDonation>();
            CreateMap<InKindDonation, addInKindDonationDTO>();

            CreateMap<updateInKindDonationDTO,InKindDonation>();
            CreateMap<InKindDonation,updateInKindDonationDTO>();

            CreateMap<addDonorDTO, Donor>();
            CreateMap<Donor, addDonorDTO>();

            CreateMap<showDonorDTO, Donor>();
            CreateMap<Donor, showDonorDTO>();

            CreateMap<showDonorWithBadgeDTO, Donor>();
            CreateMap<Donor, showDonorWithBadgeDTO>();

            CreateMap<updateDonorDTO, Donor>();
            CreateMap<Donor, updateDonorDTO>();



        }
        private byte[] ConvertIconToBytes(string iconPath)
        {
            return File.Exists(iconPath) ? File.ReadAllBytes(iconPath) : null;

            CreateMap<Donor, addDonorDTO>();
            CreateMap<addDonorDTO, Donor>();
            CreateMap<Donor, showDonorDTO>();
            CreateMap<showDonorDTO, Donor>();
            //   CreateMap<Donor, showDonorWithBadgeDTO>();
            CreateMap<showDonorWithBadgeDTO, Donor>();
            CreateMap<Donor, showDonorWithBadgeDTO>()
            .ForMember(dest => dest.BadgeName, opt => opt.MapFrom(src => src.Badges.Select(b => b.Name).ToList()));

            CreateMap<updateDonorDTO, Donor>();
            CreateMap<Donor, updateDonorDTO>();

        }




    }
}
