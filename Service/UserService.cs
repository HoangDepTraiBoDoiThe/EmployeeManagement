using EmployeeManagement.Constants;
using EmployeeManagement.Context;
using EmployeeManagement.models.ApplicationUserTables;
using EmployeeManagement.Models.ApplicationUserTables.DTOs;
using EmployeeManagement.models.EmployeeTables;
using EmployeeManagement.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Service;

public class UserService(MyIdentityDbContext dbContext, UserManager<User> userManager) : IUserService
{
    public async Task CreateEmployeesAsync(RegisterRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        var newUser = new User(request.UserName)
        {
            Email = request.Email
        };

        var result = await userManager.CreateAsync(newUser, request.Password);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        await userManager.AddToRoleAsync(newUser, ApplicationRole.Employee.ToString());
        Employee employee = new Employee(request.PHoneNumber, request.UserName, request.StartDate, newUser.Id, newUser);
        await dbContext.Employees.AddAsync(employee);
        await dbContext.SaveChangesAsync();
    }
}