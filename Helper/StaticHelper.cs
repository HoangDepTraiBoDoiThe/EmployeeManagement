using EmployeeManagement.Constants;
using EmployeeManagement.models.ApplicationUserTables;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Helper;

public static class StaticHelper
{
    public static async Task<SignInResult> EmailPasswordSignIn(this SignInManager<User> signInManager, string userEmail,
        string password, bool isPersistent, bool lockoutOnFailure)
    {
        var byNameAsync = await signInManager.UserManager.FindByEmailAsync(userEmail);
        return (object)byNameAsync == null
            ? SignInResult.Failed
            : await signInManager.PasswordSignInAsync(byNameAsync, password, isPersistent, lockoutOnFailure);
    }

    public static async Task SeedDataAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        Initializer initializer = scope.ServiceProvider.GetRequiredService<Initializer>();
        await initializer.SeedDataAsync();
    }

    public static Dictionary<EmployeeRole, string> GetJobDescriptions()
    {
        Dictionary<EmployeeRole, string> jobDescriptions = new Dictionary<EmployeeRole, string>
        {
            {
                EmployeeRole.Chief,
                "The chief is the head of the kitchen and is responsible for the overall quality of the food that is served."
            },
            {
                EmployeeRole.SousChef,
                "The sous chef is the second in command in the kitchen and is responsible for the day-to-day operations of the kitchen."
            },
            {
                EmployeeRole.Cook,
                "Cooks are responsible for preparing food according to the recipes and standards set by the chef."
            },
            {
                EmployeeRole.Waiter,
                "Waiters are responsible for taking orders, serving food, and providing excellent customer service to guests."
            },
            {
                EmployeeRole.Host,
                "Hosts are responsible for greeting guests, seating them, and managing the flow of the restaurant."
            },
            {
                EmployeeRole.Bartender,
                "Bartenders are responsible for making drinks, serving customers at the bar, and providing excellent customer service."
            },
            {
                EmployeeRole.Dishwasher,
                "Dishwashers are responsible for washing dishes, cleaning the kitchen, and keeping the kitchen organized."
            },
            {
                EmployeeRole.Manager,
                "Managers are responsible for overseeing the day-to-day operations of the restaurant, managing staff, and ensuring that the restaurant meets its goals."
            },
            {
                EmployeeRole.Busser,
                "Bussers are responsible for clearing tables, setting tables, and assisting the waitstaff in providing excellent customer service."
            }
        };

        return jobDescriptions;
    }
}