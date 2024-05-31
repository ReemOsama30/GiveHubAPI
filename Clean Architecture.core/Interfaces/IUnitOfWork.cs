using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.core.Interfaces
{
    public interface IUnitOfWork
    {
        public int save();
        public void Dispose();
    }
}
