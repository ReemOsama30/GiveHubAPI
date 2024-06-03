using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.charityDTOs;
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


            CreateMap<addCharityDTO, Charity>();
            CreateMap<Charity, showCharityDTO>();
            CreateMap<showCharityDTO, Charity>();
            CreateMap<updateCharityDTO, Charity>();
        }


    }
}
