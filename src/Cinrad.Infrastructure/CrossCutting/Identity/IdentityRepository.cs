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
            
            var result = await _userManager.CreateAsync(applicationUser, applicationUser.Password);
            
            if (result.Succeeded)
            {                
                await _userManager.AddToRoleAsync(applicationUser, role);
                ApplicationUser user = await _userManager.FindByNameAsync(applicationUser.UserName);
                var id =  user.Id;
                return id;
            }
            return Guid.Empty;
        }
       
        public async Task<ApplicationUser> GetByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return user;
        }
    }
}
