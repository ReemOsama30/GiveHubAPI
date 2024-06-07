using charityPulse.core.Models;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser UserFromDB, string PasswordFromDTO)
        {
            bool result = await _userManager.CheckPasswordAsync(UserFromDB, PasswordFromDTO);

            return result;

        }

        public async Task<IList<string>?> GetRolesAsync(ApplicationUser UserFromDB)
        {
            IList<string>? roles = await _userManager.GetRolesAsync(UserFromDB);

            return roles;

        }
    }
}
