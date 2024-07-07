using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean_Architecture.Application.services;
using Clean_Architecture.Application.DTOs.AwardedBadgeDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.DTOs.BadgeDTOs;
using Clean_Architecture.Infrastructure.Repositories;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardedBadgesController : ControllerBase
    {
        private readonly AwardedBadgeService awardedBadgeService;

        public AwardedBadgesController(AwardedBadgeService awardedBadgeService)
        {
            this.awardedBadgeService = awardedBadgeService;
        }
        [HttpPost]
        public ActionResult<GeneralResponse> Add(AwardBadgeDTO addawardBadgeDTO)
        {

            if (ModelState.IsValid)
            {
                awardedBadgeService.Add(addawardBadgeDTO);

                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = addawardBadgeDTO
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "unable to add new Awardbadge"
            };

        }


        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> Get()
        {
            List<AwardBadgeDTO> result = await awardedBadgeService.Get();

            return new GeneralResponse
            {
                IsPass = true,
                Message = result,
                Status = 200
            };

        }



        [HttpDelete]
        public ActionResult<GeneralResponse> Delete(int id)
        {
            AwardBadgeDTO awardBadge = awardedBadgeService.GetById(id);

            if (awardBadge == null)
            {
                return NotFound(new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid badge"
                });
            }


            awardedBadgeService.Delete(id);

            return Ok(new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = " deleted successfully"
            });

        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<GeneralResponse>> GetUserBadges(int id)
        {
         var awardedBadges=awardedBadgeService.GetByDonorId(id);

            if (awardedBadges == null)
            {
                return new GeneralResponse
                {
                    IsPass= false,
                    Message="invalid Badges"

                };
            }
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = awardedBadges
            };
        }

        [HttpPut]
        public ActionResult<GeneralResponse> Update(int id, AwardBadgeDTO awardBadgeDTO)
        {
            {
                AwardBadgeDTO existingAwardBadge = awardedBadgeService.GetById(id);

                if (existingAwardBadge == null)
                {
                    return NotFound(new GeneralResponse
                    {
                        IsPass = false,
                        Status = 404,
                        Message = "invalid Badge"
                    });
                }

                awardedBadgeService.Update(id, awardBadgeDTO);

                AwardBadgeDTO updatedAwardBadge = awardedBadgeService.GetById(id);

                return Ok(new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = updatedAwardBadge
                });
            }
        }

    }
}
