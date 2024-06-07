namespace Clean_Architecture.Application.DTOs.ReviewsDTOs
{
    public class ReviewDTO
    {
     
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
        public int DonorID { get; set; }

        public int CharityId { get; set; }

    }
}
