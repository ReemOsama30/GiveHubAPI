using Clean_Architecture.Application.DTOs.ReviewsDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService reviewService;

        public ReviewController(ReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAllReviews()
        {
            var review = reviewService.GetAllReviewsWithDonorInfo();
            var response = new GeneralResponse
            {
                IsPass = true,
                Message = review,
                Status = 200
            };
            return response;
        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetReviewById(int id)
        {
            var review = reviewService.GetReviewById(id);
            if (review == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "Review not Found"
                };

            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = review


                };
            }
        }


        [HttpGet("charity/{id}")]
        public ActionResult<GeneralResponse> GetAllByCharityId(int id)
        {
            var review = reviewService.GetAllReviewsOnCharity(id);
            var response = new GeneralResponse
            {
                IsPass = true,
                Message = review,
                Status = 200
            };
            return response;

        }

        [HttpPost]
        public ActionResult<GeneralResponse> AddReview(ReviewDTO reviewDTO)
        {
            if (ModelState.IsValid)
            {
                reviewService.AddReview(reviewDTO);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = reviewDTO
                };
            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 400,
                    Message = "Review Not added "
                };
            }


        }

        [HttpPut]
        public ActionResult<GeneralResponse> UpdateReview(ReviewDTOWithDoner reviewDTO)
        {
            reviewService.UpdateReview(reviewDTO);
            var review = reviewService.GetReviewById(reviewDTO.Id);
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = review
            };

        }

        [HttpDelete]
        public ActionResult<GeneralResponse> RemoveReview(int id)
        {
            var review = reviewService.GetReviewById(id);
            if (review == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "review not found"
                };
            }
            else
            {
                reviewService.DeleteReview(id);
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



