using AutoMapper;
using charityPulse.core.Models;

using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.services
{
    public class projectService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public projectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public void AddProject(addProjectDTO projectDTO)
        {
            var project = mapper.Map<Project>(projectDTO);

            project.IsDeleted = false;

            project.Img = File.ReadAllBytes(projectDTO.ImgPath);
            unitOfWork.projects.insert(project);
            unitOfWork.Save();
        }

        public async Task<List<showprojectDTO>> GetProjects()
        {
            var projects = await unitOfWork.projects.GetAllAsync();
            return mapper.Map<List<showprojectDTO>>(projects);
        }


        public showprojectDTO GetProjectById(int id)
        {
            var project = unitOfWork.projects.Get(i => i.Id == id);
            return mapper.Map<showprojectDTO>(project);
        }

        public void DeleteProject(int id)
        {
            Project project = unitOfWork.projects.Get(p => p.Id == id);
            unitOfWork.projects.delete(project);
            unitOfWork.Save();
        }

        public void updateProject(int id, updateProjectDTO newproject)
        {
            var project = unitOfWork.projects.Get(p => p.Id == id);


            project.Img = File.ReadAllBytes(newproject.Imgpath);
            unitOfWork.projects.update(project);
            unitOfWork.Save();

            if (project != null)
            {
                mapper.Map(newproject, project);

                if (!string.IsNullOrEmpty(newproject.Imgpath))
                {
                    if (File.Exists(newproject.Imgpath))
                    {
                        project.Img = File.ReadAllBytes(newproject.Imgpath);
                    }
                    else
                    {
                        project.Img = project.Img;
                    }




                    unitOfWork.projects.update(project);
                    unitOfWork.Save();
                }
            }

        }
        public List<showprojectDTO> getProjectByCharityID(int charityID)
        {
            var projects = unitOfWork.projects.GetAll().Where(p => p.CharityId == charityID);
            if (projects.Count() > 0)
            {
                return mapper.Map<List<showprojectDTO>>(projects).ToList();
            }
            else
            {
                return null;
            }
        }



        public async Task<List<showprojectDTO>> GetProjectsByPage(int page)
        {
            int pageSize = 3;


            var projects = await unitOfWork.projects.GetAllAsync();
            int totalCount = projects.Count();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var pagedProjects = projects.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return mapper.Map<List<showprojectDTO>>(pagedProjects);
        }



    }
}