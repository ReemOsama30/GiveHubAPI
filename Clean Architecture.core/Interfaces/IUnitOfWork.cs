namespace Clean_Architecture.core.Interfaces
{
    public interface IUnitOfWork
    {


        IReviewRepository ReviewRepository { get; }
        public int save();
        public void Dispose();
    }
}
