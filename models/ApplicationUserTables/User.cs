using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.models.EmployeeTables;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.models.ApplicationUserTables;

public class User : IdentityUser
{
    // Employee - one to one
    public Employee? UserEmployee { get; set; }

    public User()
    {
    }

    public User(string userName) : base(userName)
    {
    }
    
    
}