using Clean_Architecture.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.services
{
    public class AdminService
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
