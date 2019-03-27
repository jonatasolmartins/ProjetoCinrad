using Cinrad.Infrastructure.CrossCutting.Identity.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Cinrad.Infrastructure.CrossCutting.Identity
{

    public class IdentityRepository : IIdenityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IdentityRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Guid> CreateAsync(ApplicationUser applicationUser, string role)
        {
            var newPassword = "Acindb@" + applicationUser.GetHashCode();

            var result = await _userManager.CreateAsync(applicationUser, newPassword);
            if (result.Succeeded)
            {                
                await _userManager.AddToRoleAsync(applicationUser, role);
                ApplicationUser user = await _userManager.FindByEmailAsync(applicationUser.Email);
                return user.Id;
            }
            return Guid.Empty;
        }
       
    }
}
