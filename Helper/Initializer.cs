using EmployeeManagement.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Context;
using EmployeeManagement.models.ApplicationUserTables;
using EmployeeManagement.Models.ApplicationUserTables.DTOs;
using EmployeeManagement.models.EmployeeTables;
using EmployeeManagement.Service.Interfaces;

namespace EmployeeManagement.Helper
{
    public class Initializer(
        RoleManager<IdentityRole> roleManager,
        MyIdentityDbContext dbContext,
        UserManager<User> userManager,
        IUserService userService,
        IJobService jobService,
        IConfiguration configuration)
    {
        public async Task SeedDataAsync()
        {
            await InitializeRolesAsync();
            await InitializeAdminAsync();
            await InitializeEmployeesAsync();
            await InitializeJobs();
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
            IList<User> adminExists = await userManager.GetUsersInRoleAsync(ApplicationRole.Admin.ToString());
            if (adminExists.Any())
            {
                return;
            }

            var adminName = configuration["InitializeData:DefaultAdminName"];
            var adminEmail = configuration["InitializeData:DefaultAdminEmail"];
            var adminPassword = configuration["InitializeData:DefaultAdminPassword"];

            if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword) || string.IsNullOrEmpty(adminEmail))
            {
                throw new InvalidOperationException("Admin credentials are not properly configured.");
            }

            var newAdmin = new User(adminName)
            {
                Email = adminEmail
            };

            var result = await userManager.CreateAsync(newAdmin, adminPassword);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            await userManager.AddToRoleAsync(newAdmin, ApplicationRole.Admin.ToString());
        }
        private async Task InitializeEmployeesAsync()
        {
            IList<User> adminExists = await userManager.GetUsersInRoleAsync(ApplicationRole.Employee.ToString());
            if (adminExists.Any())
            {
                return;
            }

            const string userName = "TestingEmployee";
            const string email = "TestingEmployee@Gmail.com";
            const string password = "123123123123";
            
            RegisterRequest registerRequest = new RegisterRequest()
            {
                UserName = userName,
                Password = password,
                Email = email,
                PHoneNumber = "123123123",
                StartDate = DateOnly.FromDateTime(DateTime.Now)
            };
            await userService.CreateEmployeesAsync(registerRequest);
        }

        private async Task InitializeJobs()
        {
            if (await jobService.IsJobsEmpty()) return;
            var jobs = Enum.GetValues(typeof(EmployeeRole)).Cast<EmployeeRole>().Select(role => new Job(role.ToString(), StaticHelper.GetJobDescriptions()[role]));
            await jobService.CreateNewJobs(jobs);
        }
    }
}