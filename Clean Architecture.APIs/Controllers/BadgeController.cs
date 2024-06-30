using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.AwardedBadgeDTOs;
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
        private readonly BadgeService _BadgeService;

        public BadgeController(BadgeService BadgeService)
        {
            _BadgeService = BadgeService;
        }

        [HttpPost]
        public ActionResult<GeneralResponse> Add(AddBadgeDTO addBadgeDTO)
        {

            if (ModelState.IsValid)
            {
                _BadgeService.AddBadge(addBadgeDTO);

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

        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> Get()
        {
            List<ShowBadgeDTO> result = await _BadgeService.GetBadges();

            return new GeneralResponse
            {
                IsPass = true,
                Message = result,
                Status = 200
            };

        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            ShowBadgeDTO badge = _BadgeService.GetBadgeById(id);

            if (badge == null)
            {
                return NotFound(

                    new GeneralResponse
                    {
                        IsPass = false,
                        Status = 404,
                        Message = "invalid badge"
                    });

            }

            return Ok(new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = badge
            });


        }

        [HttpDelete]
        public ActionResult<GeneralResponse> Delete(int id)
        {
            ShowBadgeDTO badge = _BadgeService.GetBadgeById(id);

            if (badge == null)
            {
                return NotFound( new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid badge"
                });
            }
           
                _BadgeService.DeleteBadge(id);

                return Ok( new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = badge.Name + " deleted successfully"
                });
            
        }

        [HttpPut]
        public ActionResult<GeneralResponse> Update(int id, UpdateBadgeDTO updateBadgeDTO)
        {
            {
                ShowBadgeDTO existingBadge = _BadgeService.GetBadgeById(id);

                if (existingBadge == null)
                {
                    return  NotFound( new GeneralResponse
                    {
                        IsPass = false,
                        Status = 404,
                        Message = "invalid Badge"
                    });
                }

                _BadgeService.UpdateBadge(id, updateBadgeDTO);

                ShowBadgeDTO updatedBadge = _BadgeService.GetBadgeById(id);

                return Ok( new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = updatedBadge 
                });
            }
        }

        [HttpPost("AwardBadgeToEntity")]
        public ActionResult<GeneralResponse> AwardBadgeToEntity(AwardBadgeDTO awardBadgeDTO)
        {

            if (ModelState.IsValid)
            {
                _BadgeService.AwardBadgeToEntity(awardBadgeDTO);

                return Ok(new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = awardBadgeDTO
                });
            }
            return BadRequest(new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "unable to award new badge to user"
            });

        }


        /*
         * 






        }
        [HttpGet("donor/{id:int}")]
        public ActionResult<GeneralResponse> GetByDonnerID(int id)
        {
            List<Badge> result = _BadgeService.GetBadgesByDonnerId(id);

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
            List<Badge> result = _BadgeService.GetBadgesByCorporateId(id);

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
            List<Badge> result = _BadgeService.GetBadgesByCharityId(id);

            var response = new GeneralResponse
            {
                IsPass = true,
                Message = result,
                Status = 200
            };


            return response;
        }
         */

    }
}
