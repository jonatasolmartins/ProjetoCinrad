using System;
using System.Threading.Tasks;

namespace Cinrad.Infrastructure.CrossCutting.Identity.Interface
{
    public interface IIdenityRepository
    {
        Task<Guid> CreateAsync(ApplicationUser applicationUser, string role);
        Task<ApplicationUser> GetByName(string name);
    }
}
