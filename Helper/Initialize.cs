﻿using EmployeeManagement.Constants;
using EmployeeManagement.Context;
using EmployeeManagement.models.ApplicationUserTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeManagement.Helper;

public class Initialize()
{
    public static async void InitializeData(WebApplicationBuilder builder, MyDbContext dbContext)
    {
        if (await dbContext.Roles.AnyAsync())
            return;

        var roles = Enum.GetValues(typeof(ApplicationRole))
            .Cast<ApplicationRole>()
            .Select(role => new Role(role.ToString()));

        await dbContext.Roles.AddRangeAsync(roles);
        await dbContext.SaveChangesAsync();

        bool isAdminExit = await dbContext.Users.Include(user => user.Roles).FirstOrDefaultAsync(user =>
            user.Roles.Any(role => role.RoleName.Equals(ApplicationRole.ADMIN.ToString()))) is not null;
        if (!isAdminExit)
        {
            var adminName = builder.Configuration.GetSection("InitializeData:DefaultAdminName").Value;
            var adminPassword = builder.Configuration.GetSection("InitializeData:DefaultAdminPassword").Value;
            if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword)) return;
            
            User newAdmin = new User(adminName, "ADMIN", adminPassword);
            Role? adminRole = await dbContext.Roles.FirstOrDefaultAsync(role => role.RoleName.Equals(ApplicationRole.ADMIN));
            if (adminRole is null)
            {
                EntityEntry<Role> newRole = dbContext.Roles.Add(new Role(ApplicationRole.ADMIN.ToString()));
                dbContext.SaveChanges();
                adminRole = newRole.Entity;
            }
            newAdmin.Roles.Add(adminRole);
            dbContext.Users.Add(newAdmin);
            await dbContext.SaveChangesAsync();
        }
    }
}