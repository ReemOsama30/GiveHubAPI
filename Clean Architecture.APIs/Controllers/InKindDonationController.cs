using Clean_Architecture.Application.DTOs.InKindDonationDTOs;
using Clean_Architecture.Application.DTOs.MoneyDonationDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InKindDonationController : ControllerBase
    {
        private readonly InKindDonationService inKindDonationService;
        private readonly DonorService donorService;

        public InKindDonationController(InKindDonationService inKindDonationService, DonorService donorService)
        {
            this.inKindDonationService = inKindDonationService;
            this.donorService = donorService;
        }
        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> Get()
        {
            var inKindDonation = await inKindDonationService.GetInKindDonation();

            if (inKindDonation != null)
            {
                var response = new GeneralResponse
                {
                    IsPass = true,
                    Message = inKindDonation,
                    Status = 200
                };


                return response;
            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = "Not Found",
                Status = 400
            };

        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            var inkindDonation = inKindDonationService.GetInKindDoationById(id);
            if (inkindDonation != null)
            {
                var response = new GeneralResponse
                {
                    IsPass = true,
                    Message = inkindDonation,
                    Status = 200
                };
                return response;
            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = "Not Found",
                Status = 400
            };


        }

        [HttpGet("donor/{id}")]
        public ActionResult<GeneralResponse> GetByDonorId(int id)
        {

            List<showInKindDonationDTO > showInkindDonationDonors = inKindDonationService.GetInKindDonationByDonorId(id);
            return new GeneralResponse
            {
                IsPass = true,
                Message = showInkindDonationDonors,
                Status = 200,
            };

        }

        [HttpGet("project/{id}")]
        public ActionResult<GeneralResponse> GetByProjectId(int id)
        {

            List<showInKindDonationDTO> showInkindDonationProject = inKindDonationService.GetInKindDonationByProjectId(id);
            return new GeneralResponse
            {
                IsPass = true,
                Message = showInkindDonationProject,
                Status = 200,
            };

        }

        [HttpGet("charity/{id}")]
        public ActionResult<GeneralResponse> GetByCharityId(int id)
        {

            List<showInKindDonationDTO> showInkindDonationCharity = inKindDonationService.GetInkindDonationByCharityId(id);
            return new GeneralResponse
            {
                IsPass = true,
                Message = showInkindDonationCharity,
                Status = 200,
            };

        }

        [HttpGet("corporate/{id}")]
        public ActionResult<GeneralResponse> GetByCorporateId(int id)
        {

            List<showInKindDonationDTO> showInkindDonationCorporate = inKindDonationService.GetInkindDonationByCorporateId(id);
            return new GeneralResponse
            {
                IsPass = true,
                Message = showInkindDonationCorporate,
                Status = 200,
            };

        }

        [HttpPost]
        public ActionResult<GeneralResponse> AddInKindDonation(addInKindDonationDTO addInKindDonationDTO)
        {
            if (ModelState.IsValid)
            {
                inKindDonationService.AddInKindDonation(addInKindDonationDTO);
                return new GeneralResponse
                {
                    IsPass = true,
                    Message = "add Successfully",
                    Status = 200
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = "Failed",
                Status = 400
            };
        }

        [HttpPut]
        public ActionResult<GeneralResponse> UpdateInKindDonation(int id, updateInKindDonationDTO updateInkindDonationDTO)
        {
            var inKindDonation = inKindDonationService.GetInKindDoationById(id);

            if (inKindDonation != null)
            {
                inKindDonationService.UpdateInKindDonation(id, updateInkindDonationDTO);
                return new GeneralResponse
                {
                    IsPass = true,
                    Message = "Donation updated successfully.",
                    Status = 200,
                };

            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = "Donation not found.",
                Status = 400,
            };
        }

        [HttpDelete]
        public ActionResult<GeneralResponse> DeleteInKindDonation(int id)
        {
            var inKindDonation = inKindDonationService.GetInKindDoationById(id);
            if (inKindDonation != null)
            {
                inKindDonationService.DeleteInKindDonation(id);
                return new GeneralResponse
                {
                    IsPass = true,
                    Message = "Deleted Successfully",
                    Status = 200,
                };

            }
            return new GeneralResponse
            {
                IsPass = false,
                Message = "Cant Deleted",
                Status = 400,
            };
        }

    }
}
