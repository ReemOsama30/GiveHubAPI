using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Clean_Architecture.core.Interfaces
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(ApplicationUser UserFromDB, string PasswordFromDTO);
        Task<IList<string>?> GetRolesAsync(ApplicationUser UserFromDB);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<ApplicationUser> FindByIdAsync(string userID);
        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token);


    }
}
