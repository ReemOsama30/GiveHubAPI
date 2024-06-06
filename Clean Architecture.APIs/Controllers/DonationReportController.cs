using Clean_Architecture.Application.DTOs.DonationReportDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Donation_ReportController : ControllerBase
    {
        private readonly DonationReportService donationReportService;

        public Donation_ReportController(DonationReportService donationReportService)
        {
            this.donationReportService = donationReportService;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAllReports()
        {
            var reports = donationReportService.GetAllReports();
            var response = new GeneralResponse
            {
                IsPass = true,
                Message = reports,
                Status = 200
            };


            return response;

        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetOneReportById(int id)
        {
            var report = donationReportService.GetOne(id);
            if (report == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "Report not Found"
                };

            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = report


                };
            }


        }

        [HttpPost]
        public ActionResult<GeneralResponse> InsertDonationReport(addDonationReportDTO addDonationReportDTO)
        {

            if (ModelState.IsValid)
            {
                donationReportService.AddDonationReport(addDonationReportDTO);

                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = addDonationReportDTO
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "Cant Insert Your Donation Report"
            };

        }

        [HttpPut]
        public ActionResult<GeneralResponse> UpdateDonationReport(updateDonationReportDTO updateDonationReportDTO)
        {
            donationReportService.UpdateDonationReport(updateDonationReportDTO);
            var report = donationReportService.GetOne(updateDonationReportDTO.Id);
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = report
            };
        }

        [HttpDelete]
        public ActionResult<GeneralResponse> DeleteDonationReport(int id)
        {

            var report = donationReportService.GetOne(id);
            if (report == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "Report not Found"
                };
            }
            else
            {
                donationReportService.DeleteDonationReport(id);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = "delete successfully"
                };
            }
        }


    }
}
