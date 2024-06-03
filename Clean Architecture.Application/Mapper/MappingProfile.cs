using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.Mapper
{
    public class MappingProfile:Profile
    {

        public MappingProfile() {

            CreateMap<addProjectDTO, Project>();
            CreateMap<Project, showprojectDTO>();
            CreateMap<updateProjectDTO, Project>();
            CreateMap<AdvertismentDTO, Advertisment>();
            CreateMap<Advertisment, AdvertismentDTO>();
        }
     
         
    }
}
