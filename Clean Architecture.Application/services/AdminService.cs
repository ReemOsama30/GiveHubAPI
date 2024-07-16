using charityPulse.core.Models;
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


        public bool BlockCharity(int charityid)
        {
            Charity charity = unitOfWork.charities.Get(c => c.Id == charityid);
            if (charity == null)
            {

                return false;

            }
            else
            {
                charity.IsBlocked = true;
                unitOfWork.Save();
                return true;
            }
        }




    }
}
