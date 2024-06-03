using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.charityDTOs;

using Clean_Architecture.Application.DTOs.corporateDTOs;
using Clean_Architecture.Application.DTOs.DonationReportDTOs;

using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.Application.DTOs.ReviewsDTOs;
using Clean_Architecture.Application.DTOs.DonationReportDTOs;




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

            CreateMap<updateCorporateDTO,Corporate>();
            CreateMap<showCorporateDTO, Corporate>();


        }


    }
}
