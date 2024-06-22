using Clean_Architecture.Application.DTOs.MoneyDonationDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyDonationController : ControllerBase
    {
        private readonly MoneyDonationService moneyDonationService;
        private readonly DonorService donorService;

        public MoneyDonationController(MoneyDonationService moneyDonationService, DonorService donorService)
        {
            this.moneyDonationService = moneyDonationService;
            this.donorService = donorService;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> Get()
        {
            var money = await moneyDonationService.GetMoneyDonation();

            if (money != null)
            {
                var response = new GeneralResponse
                {
                    IsPass = true,
                    Message = money,
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
            var moneyDonation = moneyDonationService.GetMoeyDoationById(id);
            if (moneyDonation != null)
            {
                var response = new GeneralResponse
                {
                    IsPass = true,
                    Message = moneyDonation,
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

            List<showMoneyDonationDTO> showMoneyDonationDonors = moneyDonationService.GetMoneyDonationByDonorId(id);
            return new GeneralResponse
            {
                IsPass = true,
                Message = showMoneyDonationDonors,
                Status = 200,
            };

        }


        [HttpGet("project/{id}")]
        public ActionResult<GeneralResponse> GetByProjectId(int id)
        {

            List<showMoneyDonationDTO> showMoneyDonationProject = moneyDonationService.GetMoneyDonationByProjectId(id);
            return new GeneralResponse
            {
                IsPass = true,
                Message = showMoneyDonationProject,
                Status = 200,
            };

        }

        [HttpGet("charity/{id}")]
        public ActionResult<GeneralResponse> GetByCharityId(int id)
        {

            List<showMoneyDonationDTO> showMoneyDonationCharity = moneyDonationService.GetMoneyDonationByCharityId(id);
            return new GeneralResponse
            {
                IsPass = true,
                Message = showMoneyDonationCharity,
                Status = 200,
            };

        }


        [HttpGet("corporate/{id}")]
        public ActionResult<GeneralResponse> GetByCorporateId(int id)
        {

            List<showMoneyDonationDTO> showMoneyDonationCorporate = moneyDonationService.GetMoneyDonationByCorporateId(id);
            return new GeneralResponse
            {
                IsPass = true,
                Message = showMoneyDonationCorporate,
                Status = 200,
            };

        }


        [HttpPost]
        public ActionResult<GeneralResponse> AddMoneyDonation([FromForm] addMoneyDonationDTO addMoneyDonationDTO)
        {
            if (ModelState.IsValid)
            {
                moneyDonationService.AddMoneyDonation(addMoneyDonationDTO);
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
        public ActionResult<GeneralResponse> UpdateMoneyDonation(int id, updateMoneyDonationDTO updateMoneyDonationDTO)
        {
            var moneyDonation = moneyDonationService.GetMoeyDoationById(id);

            if (moneyDonation != null)
            {
                moneyDonationService.UpdateMoneyDonation(id, updateMoneyDonationDTO);
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
        public ActionResult<GeneralResponse> DeleteMoneyDonation(int id)
        {
            var moneyDonation = moneyDonationService.GetMoeyDoationById(id);
            if (moneyDonation != null)
            {
                moneyDonationService.DeleteMoneyDonation(id);
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
