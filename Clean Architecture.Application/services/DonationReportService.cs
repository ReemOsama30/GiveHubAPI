using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.DonationReportDTOs;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.services
{
    public class DonationReportService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DonationReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<donationReportDTOWithProject> GetAllReports()
        {
            var reports = unitOfWork.DonationReportRepository.GetAllReportsIncludeProject();
            return mapper.Map<List<donationReportDTOWithProject>>(reports);
        }

        public donationReportDTOWithProject GetOne(int id)
        {
            var report = unitOfWork.DonationReportRepository.GetOneWithProject(id);
            return mapper.Map<donationReportDTOWithProject>(report);
        }

        public void AddDonationReport(addDonationReportDTO addDonationReportDTO)
        {
            var report = mapper.Map<DonationReport>(addDonationReportDTO);
            report.IsDeleted = false;
            unitOfWork.DonationReportRepository.insert(report);
            unitOfWork.Save();
        }

        public void UpdateDonationReport(updateDonationReportDTO updateDonationReportDTO)
        {

            DonationReport donationReport = mapper.Map<DonationReport>(updateDonationReportDTO);
            unitOfWork.DonationReportRepository.update(donationReport);
            unitOfWork.Save();
                
           
        }

        public void DeleteDonationReport(int id)
        {
            //Project project = _unitOfWork.projects.Get(p => p.Id == id);
            DonationReport donationReport = unitOfWork.DonationReportRepository.GetOneWithProject(id);

            unitOfWork.DonationReportRepository.delete(donationReport);
        }


    }
}
