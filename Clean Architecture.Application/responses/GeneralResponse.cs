namespace Clean_Architecture.Application.responses
{
    public class GeneralResponse
    {

        public bool IsPass { set; get; }
        public dynamic Message { set; get; }

        //very important in front end
        public int Status { get; set; }

        public string? Token { get; set; } = null;

        //in case we need the expiration date
        public DateTime? Expired { get; set; } = null;
    }
}
