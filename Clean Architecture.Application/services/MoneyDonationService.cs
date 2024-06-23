using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.MoneyDonationDTOs;
using Clean_Architecture.core.Enums;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.services
{
    public class MoneyDonationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MoneyDonationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<showMoneyDonationDTO>> GetMoneyDonation()
        {
            var moneyDonation = await unitOfWork.moneyDonationRepository.GetAllAsync();
            return mapper.Map<List<showMoneyDonationDTO>>(moneyDonation);
        }

        public showMoneyDonationDTO GetMoeyDoationById(int id)
        {
            var moneyDonationByid = unitOfWork.moneyDonationRepository.Get(m => m.Id == id);
            return mapper.Map<showMoneyDonationDTO>(moneyDonationByid);
        }

        public List<showMoneyDonationDTO> GetMoneyDonationByDonorId(int id)
        {
            List<MoneyDonation> moneyDonations = unitOfWork.moneyDonationRepository.GetAll().Where(m => m.DonorId == id).ToList();
            return mapper.Map<List<showMoneyDonationDTO>>(moneyDonations);
        }

        public List<showMoneyDonationDTO> GetMoneyDonationByProjectId(int id)
        {
            List<MoneyDonation> moneyDonations = unitOfWork.moneyDonationRepository.GetAll().Where(m => m.projectId == id).ToList();
            return mapper.Map<List<showMoneyDonationDTO>>(moneyDonations);

        }


        public List<showMoneyDonationDTO> GetMoneyDonationByCharityId(int id)
        {
            List<MoneyDonation> moneyDonations = unitOfWork.moneyDonationRepository.GetAll().Where(m => m.CharityId == id).ToList();
            return mapper.Map<List<showMoneyDonationDTO>>(moneyDonations);

        }

        public List<showMoneyDonationDTO> GetMoneyDonationByCorporateId(int id)
        {
            List<MoneyDonation> moneyDonations = unitOfWork.moneyDonationRepository.GetAll().Where(m => m.CorporateId == id).ToList();
            return mapper.Map<List<showMoneyDonationDTO>>(moneyDonations);

        }

        public void AddMoneyDonation(addMoneyDonationDTO addMoneyDonationDTO)
        {
            var moneyDonation = mapper.Map<MoneyDonation>(addMoneyDonationDTO);

            unitOfWork.moneyDonationRepository.insert(moneyDonation);
         Project project=  unitOfWork.projects.Get(p=>p.Id==moneyDonation.projectId);
            project.AmountRaised += addMoneyDonationDTO.Amount;
            if (project.AmountRaised >=project.FundingGoal)
            {
                project.State = ProjectState.Compeleted;
            }
            else
            {
                project.State = ProjectState.InProgress;
            }
            unitOfWork.Save();
        }

        public void UpdateMoneyDonation(int id, updateMoneyDonationDTO updateMoneyDonationDTO)
        {

            MoneyDonation moneyDonation = unitOfWork.moneyDonationRepository.Get(m => m.Id == id);
            mapper.Map(updateMoneyDonationDTO, moneyDonation);
            unitOfWork.moneyDonationRepository.update(moneyDonation);
            unitOfWork.Save();
        }

        public void DeleteMoneyDonation(int id)
        {
            MoneyDonation moneyDonation = unitOfWork.moneyDonationRepository.Get(m => m.Id == id);
            unitOfWork.moneyDonationRepository.delete(moneyDonation);
            unitOfWork.Save();
        }
    }
}
