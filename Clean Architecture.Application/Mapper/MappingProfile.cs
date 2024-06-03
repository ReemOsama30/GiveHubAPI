using AutoMapper;
using charityPulse.core.Models;

using Clean_Architecture.Application.DTOs.corporateDTOs;

using Clean_Architecture.Application.DTOs.charityDTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;

uhttps://github.com/ReemOsama30/charityPulse/pull/18/conflict?name=Clean%2BArchitecture.Application%252FMapper%252FMappingProfile.cs&ancestor_oid=8cce098b1257e6fd11a09b18b9942635f777b731&base_oid=29830550411c24849930b3c62fca8f3ba2c4723e&head_oid=5d37a4df73fe3f00756986ad7470425af83b32ccsing Clean_Architecture.Application.DTOs.DonationReportDTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.Application.DTOs.ReviewsDTOs;


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
            CreateMap<updateCorporateDTO,Corporate>();


        }


    }
}
