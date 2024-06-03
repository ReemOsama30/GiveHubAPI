namespace Clean_Architecture.Application.DTOs.ReviewsDTOs
{
    public class ReviewDTOWithDoner
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
        public int DonorID { get; set; }
        public string DonorName { get; set; }
        public int CharityId { get; set; } // Add property for donor name

        // public string ApplicationUserId { get; set; } 

    }
}
