using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.core.Interfaces
{
    public interface ISoftDeletable
    {
         bool IsDeleted { set;  get; }
    }
}
