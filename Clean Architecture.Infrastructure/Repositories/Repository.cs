using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IsoftDeletable
    {
        protected ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().Where(e => !((IsoftDeletable)e).IsDeleted).ToListAsync();
        }
        public ICollection<T> GetAll()
        {

            //return context.Set<T>().ToList();
            return context.Set<T>().Where(e => !((IsoftDeletable)e).IsDeleted).ToList();
        }


        //public T Get(int id)
        //{
        //    return context.Set<T>().Find(id);
        //}

        public T Get(Func<T, bool> predicate) //find object by name ,id anything
        {
            //return context.Set<T>().FirstOrDefault(predicate);
            var entities = context.Set<T>().Where(e => !((IsoftDeletable)e).IsDeleted).ToList();
            return entities.FirstOrDefault(predicate);
        }

     

        //public T Getbyid(int id,string include=null)
        //{
        //    return context.Set<T>().Include(include).ToList();
        //}


        public void insert(T item)
        {

            context.Set<T>().Add(item);

        }


        public void update(T item)
        {
            context.Set<T>().Update(item);
        }

        public void delete(T item)
        {

            item.IsDeleted = true;
            update(item);

        }


    }
}
