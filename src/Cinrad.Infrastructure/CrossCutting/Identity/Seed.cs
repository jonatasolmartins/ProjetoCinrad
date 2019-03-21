using Cinrad.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Cinrad.Infrastructure.CrossCutting.Identity
{
    public class Seed
    {
        //        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        //        {
        //            //adding customs roles
        //            RoleManager<ApplicationRole> _roleManager;
        //            UserManager<ApplicationUser> _userManager;
        //            string[] roleNames = { "Admin", "Manager", "Member" };
        //            IdentityResult roleResult;
        //​
        //            foreach (var roleName in roleNames)
        //            {
        //                // creating the roles and seeding them to the database
        //                var roleExist = await RoleManager<IdentityRole>.RoleExistsAsync(roleName);
        //                if (!roleExist)
        //                {
        //                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
        //                }
        //            }
        //​
        //            // creating a super user who could maintain the web app
        //            var poweruser = new ApplicationUser
        //            {
        //                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
        //                Email = Configuration.GetSection("AppSettings")["UserEmail"]
        //            };
        //​
        //            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
        //            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);
        //​
        //            if (user == null)
        //            {
        //                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
        //                if (createPowerUser.Succeeded)
        //                {
        //                    // here we assign the new user the "Admin" role 
        //                    await UserManager.AddToRoleAsync(poweruser, "Admin");
        //                }
        //            }
        //        }
    }
}
