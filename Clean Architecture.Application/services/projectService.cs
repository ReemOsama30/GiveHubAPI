using AutoMapper;
using charityPulse.core.Models;

using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.core.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Clean_Architecture.Application.services
{
    public class projectService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public projectService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }


        public void AddProject(addProjectDTO projectDTO)
        {

            string UploadPath = Path.Combine(webHostEnvironment.WebRootPath, "projectImg");
            string imageName = Guid.NewGuid().ToString() + "-" + projectDTO.ImgPath.FileName;
            string filePath = Path.Combine(UploadPath, imageName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                projectDTO.ImgPath.CopyTo(fileStream);
            }

            var project = mapper.Map<Project>(projectDTO);

            project.ImgUrl = $"/projectImg/{imageName}"; // Store relative path

            project.IsDeleted = false;


            unitOfWork.projects.insert(project);
            unitOfWork.Save();
        }

        public async Task<List<showprojectDTO>> GetProjects()
        {
            var projects = await unitOfWork.projectRepository.GetProjectsWithCategoryNameAsync();
            return mapper.Map<List<showprojectDTO>>(projects);
        }


        public showprojectDTO GetProjectById(int id)
        {
            var project = unitOfWork.projectRepository.GetOneProjectWithCategoryName(id);


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


            //project.Img = File.ReadAllBytes(newproject.Imgpath);
            unitOfWork.projects.update(project);
            unitOfWork.Save();

            if (project != null)
            {
                mapper.Map(newproject, project);

                //if (!string.IsNullOrEmpty(newproject.Imgpath))
                //{
                //    if (File.Exists(newproject.Imgpath))
                //    {
                //        project.Img = File.ReadAllBytes(newproject.Imgpath);
                //    }
                //    else
                //    {
                //        project.Img = project.Img;
                //    }




                unitOfWork.projects.update(project);
                unitOfWork.Save();
                // }
            }

        }
        public List<showprojectDTO> getProjectByCharityID(int charityID)
        {
            var projects = unitOfWork.projectRepository.GetProjectsWithCategoryName().Where(p => p.CharityId == charityID);
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
            int pageSize = 6;


            var projects = await unitOfWork.projectRepository.GetProjectsWithCategoryNameAsync();
            int totalCount = projects.Count();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var pagedProjects = projects.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return mapper.Map<List<showprojectDTO>>(pagedProjects);
        }

        public int GetCategoryIdByName(string categoryName)
        {
            var category = unitOfWork.categoryRepository.Get(c => c.Name.ToLower() == categoryName.ToLower());

            return category.id;
        }



        public List<showprojectDTO> GetProjectsByCategoryId(int categoryId)
        {
            var projects = unitOfWork.projectRepository.GetProjectsWithCategoryName()
                                .Where(p => p.CategoryId == categoryId)
                                .ToList();

            return mapper.Map<List<showprojectDTO>>(projects);
        }



        public async Task<List<showprojectDTO>> GetProjectsByFundingGoalRange()
        {
            var Projects = await unitOfWork.projectRepository.GetProjectsWithCategoryNameAsync();
            var FilteredProjects = Projects
                                    .Where(p => p.FundingGoal >= 1000 && p.FundingGoal <= 5000)
                                    .ToList();
            return mapper.Map<List<showprojectDTO>>(FilteredProjects);
        }


        public async Task<List<showprojectDTO>> GetProjectsByMAXFundingGoal()
        {
            var Projects = await unitOfWork.projectRepository.GetProjectsWithCategoryNameAsync();
            var FilteredProjects = Projects
                                   .Where(p => p.FundingGoal >= 5000)
                                   .ToList();
            return mapper.Map<List<showprojectDTO>>(FilteredProjects);
        }

        public async Task<List<showprojectDTO>> GetProjectsByMINIFundingGoal()
        {
            var Projects = await unitOfWork.projectRepository.GetProjectsWithCategoryNameAsync();
            var FilteredProjects = Projects
                                   .Where(p => p.FundingGoal <= 1000)
                                   .ToList();
            return mapper.Map<List<showprojectDTO>>(FilteredProjects);
        }


        //apply 2 filter together
        public async Task<List<showprojectDTO>> GetProjectsByCategoryNameAndBudgetRange(string categoryName)
        {
            var category = unitOfWork.categoryRepository.Get(c => c.Name.ToLower() == categoryName.ToLower());


            var projects = await unitOfWork.projectRepository.GetProjectsWithCategoryNameAsync();
            var filteredProjects = projects
                                    .Where(p => p.CategoryId == category.id &&
                                                p.FundingGoal >= 1000 && p.FundingGoal <= 5000)
                                    .ToList();
            return mapper.Map<List<showprojectDTO>>(filteredProjects);
        }

        public async Task<List<showprojectDTO>> GetProjectsByCategoryNameAndMAXFundingGoal(string categoryName)
        {
            var category = unitOfWork.categoryRepository.Get(c => c.Name.ToLower() == categoryName.ToLower());


            var projects = await unitOfWork.projectRepository.GetProjectsWithCategoryNameAsync();
            var filteredProjects = projects
                                    .Where(p => p.CategoryId == category.id &&
                                                p.FundingGoal >= 5000)
                                    .ToList();
            return mapper.Map<List<showprojectDTO>>(filteredProjects);
        }

        public async Task<List<showprojectDTO>> GetProjectsByCategoryNameAndMINIFundingGoal(string categoryName)
        {
            var category = unitOfWork.categoryRepository.Get(c => c.Name.ToLower() == categoryName.ToLower());


            var projects = await unitOfWork.projectRepository.GetProjectsWithCategoryNameAsync();
            var filteredProjects = projects
                                    .Where(p => p.CategoryId == category.id &&
                                                p.FundingGoal <= 1000)
                                    .ToList();
            return mapper.Map<List<showprojectDTO>>(filteredProjects);
        }

    }
}