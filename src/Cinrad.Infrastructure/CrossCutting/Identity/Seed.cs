using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinrad.Infrastructure.CrossCutting.Identity
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceCollection service, IConfiguration Configuration)
        {
            //Adicionando roles customizadas
            var RoleManager = service.BuildServiceProvider().GetRequiredService<RoleManager<ApplicationRole>>();
            var UserManager = service.BuildServiceProvider().GetRequiredService<UserManager<ApplicationUser>>();

            var roles = new List<ApplicationRole>() {
                new ApplicationRole("Admin","Usuário Administrador"),
                new ApplicationRole("Cliente","Usuário Cliente"),
                new ApplicationRole("Transportador","Usuário Transportadora"),
                new ApplicationRole("Supervisor","Usuário Supervisor"),
                new ApplicationRole("PowerUser","Super Powerfull User")
            };
            IdentityResult roleResult;​

            foreach (var role in roles)
            {
                // Criando as roles e persistindo no banco
                var roleExist = await RoleManager.RoleExistsAsync(role.Name);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(role);
                }
            }​
            // Criando um super usuário que pode interagir com qualquer parte do app
            var poweruser = new ApplicationUser
            {
                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
                Email = Configuration.GetSection("AppSettings")["UserEmail"]
            };
​
            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // Adicionando a role PowerUser para o novo usuário 
                    await UserManager.AddToRoleAsync(poweruser, "PowerUser");
                }
            }
        }
    }
}
