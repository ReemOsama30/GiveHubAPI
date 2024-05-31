using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.Interfaces
{
    public interface IRepository<T> where T : class, IsoftDeletable
    {
        public ICollection<T> GetAll();
        public T Get(int id);
        public void insert(T item);
        public void update(T item);
        public void delete(T item);
        public int save();
    }
}
