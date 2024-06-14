using Clean_Architecture.Application.DTOs.corporateDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Clean_Architecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class corporateController : ControllerBase
    {
        private readonly corporateService corporateService;

        public corporateController(corporateService corporateService)
        {
            this.corporateService = corporateService;
        }


        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> Get()
        {

            var result = await corporateService.getAllCorporates();

            var response = new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = result
            };

            return response;

        }


        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> getById(int id)
        {
            var corporate = corporateService.getById(id);
            if (corporate == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "invalid corporate"
                };
            }
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = corporate
            };
        }

        [HttpDelete]
        public ActionResult<GeneralResponse> delete(int id)
        {
            var corporate = corporateService.getById(id);
            if (corporate == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 400,
                    Message = "invalid corporate"
                };
            }

            corporateService.deleteCorporate(id);
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = corporate.WebsiteUrl + "deleted successfully"
            };
        }


        [HttpPost]
        public ActionResult<GeneralResponse> Insert(addCorporateDTO addCorporateDTO)
        {
            corporateService.addCorporate(addCorporateDTO);
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = addCorporateDTO
            };
        }

        [HttpPut]
        public ActionResult<GeneralResponse> update(int id, updateCorporateDTO updateCorporateDTO)
        {
            {
                var existingCorporate = corporateService.getById(id);
                if (existingCorporate == null)
                {
                    return new GeneralResponse
                    {
                        IsPass = false,
                        Status = 400,
                        Message = "invalid corporate"
                    };
                }
                corporateService.updateCoroprate(id, updateCorporateDTO);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = updateCorporateDTO
                };
            }


        }

    }
}
