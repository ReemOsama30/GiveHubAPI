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
            var review = unitOfWork.reviewRepository.GetOneWithDonorInfo(id);
            return mapper.Map<ReviewDTOWithDoner>(review);
        }


        public List<ReviewDTOWithDoner> GetAllReviewsWithDonorInfo()
        {
            var reviews = unitOfWork.reviewRepository.GetAllReviewsWithDonorInfo();
            return mapper.Map<List<ReviewDTOWithDoner>>(reviews);
        }

        public List<ReviewDTOWithDoner> GetAllReviewsOnCharity(int charityId)
        {
            var reviews = unitOfWork.reviewRepository.GetByCharityId(charityId);
            return mapper.Map<List<ReviewDTOWithDoner>>(reviews);

        }


        public void AddReview(ReviewDTO reviewDTO)
        {

            var review = mapper.Map<Review>(reviewDTO);
            review.DatePosted = DateTime.Now;
            unitOfWork.reviewRepository.insert(review);
            unitOfWork.Save();
        }


        public void UpdateReview(int id,ReviewDTO reviewDTO)
        {

            var review =unitOfWork.reviewRepository.Get(r=>r.Id==id);
                mapper.Map(reviewDTO,review);
                
     
            review.DatePosted = DateTime.Now;
            unitOfWork.reviewRepository.update(review);
            unitOfWork.Save();
        }

        public void deleteReview(int id)
        {
            Review review = unitOfWork.reviewRepository.Get(c => c.Id == id);
            unitOfWork.reviewRepository.delete(review);
            unitOfWork.Save();
        }
    }


}

