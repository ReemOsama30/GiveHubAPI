namespace Clean_Architecture.Application.Interfaces
{
    public interface IRepository<T> where T : class, IsoftDeletable
    {
        public ICollection<T> GetAll();
        //public T Get(int id);
        public T Get(Func<T, bool> predicate);
        public void insert(T item);
        public void update(T item);
        public void delete(T item);

        public Task<IEnumerable<T>> GetAllAsync();

    }
}
