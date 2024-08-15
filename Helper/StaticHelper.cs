using EmployeeManagement.models.ApplicationUserTables;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Helper;

public static class StaticHelper
{
    public static async Task<SignInResult> EmailPasswordSignIn(this SignInManager<User> signInManager, string userEmail, string password, bool isPersistent, bool lockoutOnFailure)
    {
        var byNameAsync = await signInManager.UserManager.FindByEmailAsync(userEmail);
        return (object) byNameAsync == null ? SignInResult.Failed : await signInManager.PasswordSignInAsync(byNameAsync, password, isPersistent, lockoutOnFailure);
    }
    
    public static async Task SeedDataAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        Initializer initializer = scope.ServiceProvider.GetRequiredService<Initializer>();
        await initializer.SeedDataAsync();
    }
}