using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.DonorDTOs;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.services
{
    public class DonorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DonorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<showDonorDTO>> GetDonors()
        {
            var donors = await unitOfWork.donorRepository.GetAllAsync();
            return mapper.Map<List<showDonorDTO>>(donors);
        }
        public showDonorDTO GetDonorById(int id)
        {
            var donor = unitOfWork.donorRepository.Get(i => i.Id == id);
            return mapper.Map<showDonorDTO>(donor);
        }
        public async Task<List<showDonorWithBadgeDTO>> GetDonorsWithBadges()
        {
            var donors = await unitOfWork.donorRepository.GetAllDonorWithBadgeAsync();
            return mapper.Map<List<showDonorWithBadgeDTO>>(donors);
        }

        public void AddDonor(addDonorDTO addDonorDTO)
        {
            var donor = mapper.Map<Donor>(addDonorDTO);

            donor.ProfileImg = File.ReadAllBytes(addDonorDTO.Img);
            donor.ApplicationUserId = "439213c3-e1c8-4fc5-a601-9d441a657dbd";
            unitOfWork.donorRepository.insert(donor);
            unitOfWork.save();
        }

        public void UpdateDonor(updateDonorDTO updateDonorDTO)
        {
            Donor donor = mapper.Map<Donor>(updateDonorDTO);

            donor.ProfileImg = File.ReadAllBytes(updateDonorDTO.img);
            donor.ApplicationUserId = "439213c3-e1c8-4fc5-a601-9d441a657dbd";
            unitOfWork.donorRepository.update(donor);
            unitOfWork.save();

        }
        public void DeleteDonor(int id)
        {
            Donor donor = unitOfWork.donorRepository.Get(d => d.Id == id);
            unitOfWork.donorRepository.delete(donor);
            unitOfWork.save();
        }

    }
}
