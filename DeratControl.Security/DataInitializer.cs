using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Security
{
    public static class DataInitializer
    {
        public static async Task SeedData(UserManager<SecurityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }
        public static async Task SeedUsers(UserManager<SecurityUser> userManager)
        {
            string username = "admin";
            string password = "Admin!2345";
            if (await userManager.FindByNameAsync(username) == null)
            {
               //User
                SecurityUser admin = new SecurityUser();
                admin.Email = "admin@gmail.com";
                admin.UserName = "admin";
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Customer", "Employee", "Admin" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (roleExist == false) 
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
