using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class projectController : ControllerBase
    {
        private readonly projectService projectService;

        public projectController(projectService projectService)
        {
            this.projectService = projectService;
        }
        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> get()
        {
            var result = await projectService.GetProjects();

            var response = new GeneralResponse
            {
                IsPass = true,

                Message = result,
                Status = 200
            };


            return response;
        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> getbyId(int id)
        {
            var project = projectService.GetProjectById(id);
            if (project == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid project"
                };

            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = project


                };
            }

        }


        [HttpGet("charity/{id}")]
        public ActionResult<GeneralResponse> getByCharityID(int id)
        {
            var project = projectService.getProjectByCharityID(id);

            if (project == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid charity id"
                };
            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = project
                };

            }

        }


        [HttpPut("{id}")]
        public ActionResult<GeneralResponse> update(int id, updateProjectDTO updateProjectDTO)
        {
            projectService.updateProject(id, updateProjectDTO);
            var project = projectService.GetProjectById(id);
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = "updateProjectDTO successfully"
            };

        }


        [HttpDelete]
        public ActionResult<GeneralResponse> deleteProject(int id)
        {

            var project = projectService.GetProjectById(id);
            if (project == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid project"
                };
            }
            else
            {
                projectService.DeleteProject(id);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = project.Title + "delete successfully"
                };
            }
        }


        //[Authorize]
        [HttpPost]
        public ActionResult<GeneralResponse> InsertProject(addProjectDTO addProjectDTO)
        {

            if (ModelState.IsValid)
            {
                projectService.AddProject(addProjectDTO);

                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = addProjectDTO
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "unable to add new project"
            };

        }



        [HttpGet("page")]
        public async Task<ActionResult<GeneralResponse>> GetAll(int page)
        {
            var result = await projectService.GetProjectsByPage(page);

            var response = new GeneralResponse
            {
                IsPass = true,

                Message = result,
                Status = 200
            };
            return response;
        }


        [HttpGet("category-id")]
        public ActionResult<GeneralResponse> GetCategoryIdByName(string categoryName)
        {
            var categoryId = projectService.GetCategoryIdByName(categoryName);

            if (categoryId != 0)
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = categoryId
                };
            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = $"this category  '{categoryName}' not found"
                };
            }
        }

        [HttpGet("category/{categoryName}")]
        public ActionResult<GeneralResponse> GetProjectsByCategoryName(string categoryName)
        {
            var categoryId = projectService.GetCategoryIdByName(categoryName);

            if (categoryId == 0)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = $"this category  '{categoryName}' not found"
                };
            }

            var projects = projectService.GetProjectsByCategoryId(categoryId);

            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = projects
            };
        }

        [HttpGet("funding-goal-range")]
        public async Task<ActionResult<GeneralResponse>> GetProjectsByFundingGoalRange()
        {
            var Projects = await projectService.GetProjectsByFundingGoalRange();
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = Projects
            };
        }

        [HttpGet("MAX-funding-goal")]
        public async Task<ActionResult<GeneralResponse>> GetProjectsByMAXFundingGoal()
        {
            var Projects = await projectService.GetProjectsByMAXFundingGoal();
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = Projects
            };
        }

        [HttpGet("MINI-funding-goal")]
        public async Task<ActionResult<GeneralResponse>> GetProjectsByMINIFundingGoal()
        {
            var Projects = await projectService.GetProjectsByMINIFundingGoal();
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = Projects
            };
        }
        [HttpGet("filter-category-range")]
        public async Task<ActionResult<GeneralResponse>> GetProjectsByCategoryNameAndBudgetRange(string categoryName)
        {
            var projects = await projectService.GetProjectsByCategoryNameAndBudgetRange(categoryName);

            if (projects == null || projects.Count == 0)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "No projects found "
                };
            }

            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = projects
            };
        }


        [HttpGet("filter-category-MINIFunding")]
        public async Task<ActionResult<GeneralResponse>> GetProjectsByCategoryNameAndMINIFunding(string categoryName)
        {
            var projects = await projectService.GetProjectsByCategoryNameAndMINIFundingGoal(categoryName);

            if (projects == null || projects.Count == 0)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "No projects found "
                };
            }

            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = projects
            };
        }


        [HttpGet("filter-category-MaxFunding")]
        public async Task<ActionResult<GeneralResponse>> GetProjectsByCategoryNameAndMaxFunding(string categoryName)
        {
            var projects = await projectService.GetProjectsByCategoryNameAndMAXFundingGoal(categoryName);

            if (projects == null || projects.Count == 0)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "No projects found "
                };
            }

            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = projects
            };
        }


    }
}
