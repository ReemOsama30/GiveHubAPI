using Clean_Architecture.Application.DTOs.charityDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class charityController : ControllerBase
    {
        private readonly charityService charityService;

        public charityController(charityService charityService)
        {
            this.charityService = charityService;
        }
        [HttpPost]
        public ActionResult<GeneralResponse> InsertCharity(addCharityDTO charityDTO)
        {
            if (ModelState.IsValid)
            {
               
                charityService.addCharity(charityDTO);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = charityDTO
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "Can't Add New Charity"
            };
        }

        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<GeneralResponse>> GetAllCharites()
        {
            List<showCharityDTO> charityDTOs = await charityService.getCharities();
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = charityDTOs

            };

        }
        [HttpGet("getByCharityId/{id}")]
        public ActionResult<GeneralResponse> getByCharityId(int id)
        {
            showCharityDTO charityDTO = charityService.getCharityById(id);
            if (charityDTO != null)
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = charityDTO,
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "Invalid Id",
            };
        }
        [HttpGet("getCharitiesForSpecificUser/{id}")]
        public ActionResult<GeneralResponse> getCharitiesForSpecificUser(string id)
        {
            showCharityDTO charityDTOs = charityService.getCharitiesByAccountId(id);
            if (charityDTOs != null)
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = charityDTOs,
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "Invalid Id",
            };
        }
        [HttpPut]
        public ActionResult<GeneralResponse> updateCharity(int id, updateCharityDTO charityDTO)
        {
            charityService.updateCharity(id, charityDTO);
            var charity = charityService.getCharityById(id);
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = charity
            };
        }
        [HttpDelete]
        public ActionResult<GeneralResponse> deleteCharity(int id)
        {
            var charity = charityService.getCharityById(id);
            if (charity != null)
            {
                charityService.deleteCharity(id);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = "Deleted Successfully"
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "Not Found"
            };


        }


        [HttpGet("getCharityID/{id:guid}")]
        public ActionResult<int> getCharityIdByUserId(string id)
        {


            int charityId = charityService.GetCharityIdByUserID(id);
            return charityId;



        }

        [HttpGet("getAccountID/{name:alpha}")]
        public ActionResult<GeneralResponse> GetAccountID(string name)
        {
            string accountID = charityService.getAccountIdBYcharityName(name);
            if (accountID == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 400,
                    Message = "Not Found"
                };
            }
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = accountID
            };
        }


    }
}
