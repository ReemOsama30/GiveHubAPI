using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.projectDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Http;
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


        [HttpPut]
        public ActionResult<GeneralResponse> update(updateProjectDTO updateProjectDTO)
        {
            projectService.updateProject(updateProjectDTO);
            var project = projectService.GetProjectById(updateProjectDTO.Id);
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = project
            };

        }


        [HttpDelete]
        public ActionResult<GeneralResponse> deleteProject(int id)
        {

            var project=projectService.GetProjectById(id);
            if(project == null)
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
                    IsPass= true,
                    Status = 200,
                    Message = project.Title+"delete successfully"
                };
            }
        }
    }
}
