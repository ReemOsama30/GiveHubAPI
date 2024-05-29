using charityPulse.core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityPulse.Infrastructure.context
{
    public class context:IdentityDbContext<ApplicationUser>
    {

    }
}
