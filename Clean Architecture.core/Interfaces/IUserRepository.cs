using charityPulse.core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.core.Interfaces
{
    public interface IUserRepository
    {
       
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(ApplicationUser UserFromDB, string PasswordFromDTO);
        Task<IList<string>?> GetRolesAsync(ApplicationUser UserFromDB);


    }
}
