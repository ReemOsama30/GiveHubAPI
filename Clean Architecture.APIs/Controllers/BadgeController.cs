using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : ControllerBase
    {
        private readonly BadgeService BadgeService;

        public BadgeController(BadgeService BadgeService)
        {
            this.BadgeService = BadgeService;
        }
        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> Get()
        {
            var result = await BadgeService.GetBadgs();

            var response = new GeneralResponse
            {
                IsPass = true,
                Message = result,
                Status = 200
            };

            //add
            return response;
        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetbyId(int id)
        {
            var badge = BadgeService.GetBadgeById(id);
            if (badge == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid badge"
                };

            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = badge


                };
            }

        }

        [HttpPost]
        public ActionResult<GeneralResponse> InsertBadge(AddBadgeDTO addBadgeDTO)
        {

            if (ModelState.IsValid)
            {
                BadgeService.AddBadge(addBadgeDTO);

                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = addBadgeDTO
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "unable to add new badge"
            };

        }
        [HttpDelete]
        public ActionResult<GeneralResponse> DeleteBadge(int id)
        {

            var badge = BadgeService.GetBadgeById(id);
            if (badge == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid badge"
                };
            }
            else
            {
                BadgeService.DeleteBadge(id);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = badge.Name + "delete successfully"
                };
            }
        }

        [HttpPut]
        public ActionResult<GeneralResponse> Update(int id, UpdateBadgeDTO updateBadgeDTO)
        {
            {
                var existingBadge = BadgeService.GetBadgeById(id);
                if (existingBadge == null)
                {
                    return new GeneralResponse
                    {
                        IsPass = false,
                        Status = 400,
                        Message = "invalid Badge"
                    };
                }
                BadgeService.UpdateBadge(id, updateBadgeDTO);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = updateBadgeDTO
                };
            }


        }
        [HttpGet("donor/{id:int}")]
        public ActionResult<GeneralResponse> GetByDonnerID(int id)
        {
            List<Badge> result = BadgeService.GetBadgesByDonnerId(id);

            var response = new GeneralResponse
            {
                IsPass = true,
                Message = result,
                Status = 200
            };


            return response;
        }

        [HttpGet("corporate/{id:int}")]
        public ActionResult<GeneralResponse> GetByCorporateID(int id)
        {
            List<Badge> result = BadgeService.GetBadgesByCorporateId(id);

            var response = new GeneralResponse
            {
                IsPass = true,
                Message = result,
                Status = 200
            };


            return response;
        }

        [HttpGet("charity/{id:int}")]
        public ActionResult<GeneralResponse> GetByCharityID(int id)
        {
            List<Badge> result = BadgeService.GetBadgesByCharityId(id);

            var response = new GeneralResponse
            {
                IsPass = true,
                Message = result,
                Status = 200
            };


            return response;
        }
    }
}
