using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.core.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.services
{
    public class projectService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public projectService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public void AddProject(addProjectDTO projectDTO)
        {
            var project = mapper.Map<Project>(projectDTO);
            project.IsDeleted = false;

             unitOfWork.projects.insert(project);
             unitOfWork.save();
        }

        public async Task<List<showprojectDTO>> GetProjects()
        {
            var projects = await unitOfWork.projects.GetAllAsync();
            return mapper.Map<List<showprojectDTO>>(projects);
        }


        public showprojectDTO GetProjectById(int id)
        {
            var project= unitOfWork.projects.Get(i=>i.Id==id);
            return mapper.Map<showprojectDTO>(project);
        }

        public void DeleteProject(int id)
        {
            Project project = unitOfWork.projects.Get(p => p.Id == id);
          unitOfWork.projects.delete(project);
        }

        public void updateProject(updateProjectDTO newproject)
        {
            Project project=mapper.Map<Project>(newproject);
            unitOfWork.projects.update(project);
            unitOfWork.save();  
        }
        public List<showprojectDTO>getProjectByCharityID(int charityID)
        {
            var projects= unitOfWork.projects.GetAll().Where(p => p.CharityId == charityID);
            return mapper.Map<List<showprojectDTO>>(projects).ToList();

        }
    }
}