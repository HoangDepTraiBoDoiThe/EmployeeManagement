using EmployeeManagement.Auth;
using EmployeeManagement.Constants;
using EmployeeManagement.Context;
using EmployeeManagement.DTOs.Auth;
using EmployeeManagement.Helper;
using EmployeeManagement.Models.ApplicationUserTables.DTOs.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeeManagement.models.ApplicationUserTables;
public interface IAuthService
{
    public Task<GeneralResponse> UserLogin(LoginRequest request);
    public Task<GeneralResponse> UserRegister(LoginRequest request);
}
public class AuthService(MyDbContext dbContext, IOptions<JwtSection> jwtSection) : IAuthService
{
    public async Task<GeneralResponse> UserLogin(LoginRequest request)
    {
        User? exitingUser = await dbContext.Users.Include(user => user!.Roles).FirstOrDefaultAsync(user => user!.UserName.Equals(request.UserName));
        if (exitingUser is null) return new GeneralResponse("User name not found");

        if (BCrypt.Net.BCrypt.Verify(request.UserPassword, exitingUser.Password) is not true) return new GeneralResponse("Password is incorrect");

        string token = AuthUtils.GenerateToken(exitingUser, jwtSection);
        return new LoginResponse("Login successfully", token);
    }

    public async Task<GeneralResponse> UserRegister(LoginRequest request)
    {
        User? exitingUser = await dbContext.Users.FirstOrDefaultAsync(user => user!.UserName.Equals(request.UserName));
        if (exitingUser is not null) return new RegisterResponse("User name already exists");

        User newUser = new User(request.UserName, BCrypt.Net.BCrypt.HashPassword(request.UserPassword));
        Role? initRole = await dbContext.Roles.FirstOrDefaultAsync(role => role.RoleName.Equals(ApplicationRole.GUESS));
        if (initRole is not null) newUser.Roles.Add(initRole);
        dbContext.Users.Add(newUser);
        
        return new RegisterResponse("User created successfully");
    }
}