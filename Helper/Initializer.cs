using EmployeeManagement.Constants;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.models.ApplicationUserTables;

namespace EmployeeManagement.Helper
{
    public class Initializer(
        RoleManager<IdentityRole> roleManager,
        UserManager<User> userManager,
        IConfiguration configuration)
    {
        public async Task SeedDataAsync()
        {
            await InitializeRolesAsync();
            await InitializeAdminAsync();
        }

        private async Task InitializeRolesAsync()
        {
            if (await roleManager.Roles.AnyAsync())
            {
                return;
            }

            var roles = Enum.GetValues(typeof(ApplicationRole))
                .Cast<ApplicationRole>()
                .Select(role => new IdentityRole(role.ToString()));

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }

        private async Task InitializeAdminAsync()
        {
            IList<User> adminExists = await userManager.GetUsersInRoleAsync(ApplicationRole.ADMIN.ToString());
            if (adminExists.Any())
            {
                return;
            }

            var adminName = configuration["SeedData:DefaultAdminName"];
            var adminPassword = configuration["SeedData:DefaultAdminPassword"];

            if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword))
            {
                throw new InvalidOperationException("Admin credentials are not properly configured.");
            }

            var newAdmin = new User(adminName);
            var result = await userManager.CreateAsync(newAdmin, adminPassword);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            await userManager.AddToRoleAsync(newAdmin, ApplicationRole.ADMIN.ToString());
        }
    }

    public static class InitializerExtensions
    {
        public static async Task SeedDataAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<Initializer>();
            await initializer.SeedDataAsync();
        }
    }
}