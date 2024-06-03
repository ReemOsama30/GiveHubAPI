namespace Clean_Architecture.Application.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
        public int DonorID { get; set; }

        public int CharityId { get; set; }

    }
}
