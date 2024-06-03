using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.DonationReportDTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;

namespace Clean_Architecture.Application.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<addProjectDTO, Project>();
            CreateMap<Project, showprojectDTO>();
            CreateMap<updateProjectDTO, Project>();

            CreateMap<donationReportDTOWithProject, DonationReport>();
            CreateMap<DonationReport, donationReportDTOWithProject>();
            CreateMap<updateDonationReportDTO, DonationReport>();
            CreateMap<DonationReport, updateDonationReportDTO>();
            CreateMap<addDonationReportDTO, DonationReport>();
            CreateMap<DonationReport, addDonationReportDTO>();
        }


    }
}
