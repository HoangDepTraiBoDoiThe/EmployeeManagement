using EmployeeManagement.Constants;
using EmployeeManagement.Context;
using EmployeeManagement.models.ApplicationUserTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeManagement.Helper;

public class Initialize()
{
    public static void InitializeData(WebApplicationBuilder builder, MyDbContext dbContext)
    {
        if (!dbContext.Roles.Any())
        {
            var roles = Enum.GetValues(typeof(ApplicationRole))
                .Cast<ApplicationRole>()
                .Select(role => new Role(role.ToString()));

            dbContext.Roles.AddRange(roles);
            dbContext.SaveChanges();
        }

        bool isAdminExit = dbContext.Users.Include(user => user.Roles).FirstOrDefault(user =>
            user.Roles.Any(role => role.RoleName.Equals(ApplicationRole.ADMIN.ToString()))) is not null;
        if (!isAdminExit)
        {
            var adminName = builder.Configuration.GetSection("InitializeData:DefaultAdminName").Value;
            var adminPassword = builder.Configuration.GetSection("InitializeData:DefaultAdminPassword").Value;
            if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword)) return;
            
            User newAdmin = new User(adminName, "ADMIN", BCrypt.Net.BCrypt.HashPassword(adminPassword));
            Role? adminRole = dbContext.Roles.FirstOrDefault(role => role.RoleName.Equals(ApplicationRole.ADMIN));
            if (adminRole is null)
            {
                EntityEntry<Role> newRole = dbContext.Roles.Add(new Role(ApplicationRole.ADMIN.ToString()));
                dbContext.SaveChanges();
                adminRole = newRole.Entity;
            }
            newAdmin.Roles.Add(adminRole);
            dbContext.Users.Add(newAdmin);
            dbContext.SaveChanges();
        }
    }
}