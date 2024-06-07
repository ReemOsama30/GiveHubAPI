using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.advertismentDTO;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Clean_Architecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertismentController : ControllerBase
    {
        private readonly AdvertismentService advertismentService;

        public AdvertismentController( AdvertismentService advertismentService) 
        {
            this.advertismentService = advertismentService;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> get()
        {
            var result = await advertismentService.GetAdvertisments();

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
            var advertisment = advertismentService.GetAdvertismentById(id);
            if (advertisment == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid Advertisment"
                };

            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = advertisment


                };
            }

        }
        [HttpPut("{id}")]
        public ActionResult<GeneralResponse> update(int id,UpdateAsdvertismentDTO advertismentDTO)
        {
           
            var advertisment = advertismentService.GetAdvertismentById(id);

            if (advertisment != null)
            {
                advertismentService.updateAdvertisment(id, advertismentDTO);
               
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = "updated successfully!!!"
                };
            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 400,
                    Message = "invalid advertisment id"

                };
            }
        }


        [HttpPost]
        public ActionResult<GeneralResponse> InsertAdvertisment(AdvertismentDTO advertismentDTO)
        {

            if (ModelState.IsValid)
            {
                advertismentService.AddAdvertisment(advertismentDTO);

                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = advertismentDTO
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "unable to add new advertisment"
            };

        }

        [HttpDelete]
        public ActionResult<GeneralResponse> deleteAdvertisment(int id)
        {

            var advertisment = advertismentService.GetAdvertismentById(id);
            if (advertisment == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid Advertisment"
                };
            }
            else
            {
                advertismentService.DeleteAdvertisment(id);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message ="Deleted successfully"
                };
            }
        }
    }
}
