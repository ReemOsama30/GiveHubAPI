using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs;
using Clean_Architecture.Application.DTOs.projectDTOs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clean_Architecture.Application.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {


            CreateMap<addProjectDTO, Project>();
            CreateMap<Project, showprojectDTO>();
            CreateMap<updateProjectDTO, Project>();


            CreateMap<Review, ReviewDTOWithDoner>();
            CreateMap<ReviewDTOWithDoner, Review>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();

            //CreateMap<Review, ReviewDTO>()
            //   .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Donor.ApplicationUserId)); 


            

        }


    }
}
