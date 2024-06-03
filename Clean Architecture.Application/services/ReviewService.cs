using AutoMapper;
using charityPulse.core.Models;
using Clean_Architecture.Application.DTOs.ReviewsDTOs;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.services
{
    public class ReviewService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }



        public ReviewDTOWithDoner GetReviewById(int id)
        {
            var review = unitOfWork.ReviewRepository.GetOneWithDonorInfo(id);
            return mapper.Map<ReviewDTOWithDoner>(review);
        }


        public List<ReviewDTOWithDoner> GetAllReviewsWithDonorInfo()
        {
            var reviews = unitOfWork.ReviewRepository.GetAllReviewsWithDonorInfo();
            return mapper.Map<List<ReviewDTOWithDoner>>(reviews);
        }

        public List<ReviewDTOWithDoner> GetAllReviewsOnCharity(int charityId)
        {
            var reviews = unitOfWork.ReviewRepository.GetByCharityId(charityId);
            return mapper.Map<List<ReviewDTOWithDoner>>(reviews);

        }


        public void AddReview(ReviewDTO reviewDTO)
        {

            var review = mapper.Map<Review>(reviewDTO);
            review.DatePosted = DateTime.Now;
            unitOfWork.ReviewRepository.insert(review);
            unitOfWork.save();
        }


        public void UpdateReview(ReviewDTOWithDoner reviewDTO)
        {
            var review = mapper.Map<Review>(reviewDTO);
            review.DatePosted = DateTime.Now;
            unitOfWork.ReviewRepository.update(review);
            unitOfWork.save();
        }

        public void DeleteReview(int id)
        {
            Review review = unitOfWork.ReviewRepository.Get(r => r.Id == id);
            unitOfWork.ReviewRepository.delete(review);
        }
    }


}

