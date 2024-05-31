using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IsoftDeletable
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<T> GetAll()
        {

            return context.Set<T>().ToList();
        }


        public T Get(int id)
        {
            return context.Set<T>().Find(id);
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

        public int save()
        {
            return context.SaveChanges();
        }
    }
}
