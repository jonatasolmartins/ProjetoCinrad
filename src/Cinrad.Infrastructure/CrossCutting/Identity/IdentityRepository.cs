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

        public async Task<Guid> CreateAsync(ApplicationUser applicationUser)
        {
            var result = await _userManager.CreateAsync(applicationUser, "Acindb@"+applicationUser.GetHashCode());
            if (result.Succeeded)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(applicationUser.Email);
                return user.Id;
            }
            return Guid.Empty;
        }
    }
}
