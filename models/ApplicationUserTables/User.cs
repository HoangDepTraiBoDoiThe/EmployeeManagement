using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.models.EmployeeTables;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.models.ApplicationUserTables;

public class User : IdentityUser
{
    // [Key]
    // public int Id { get; set; }
    
    // [StringLength(100, MinimumLength = 2)]
    // [Required(ErrorMessage = "User name is required.")]
    // public string UserName { get; set; } = null!;
    // [Required(ErrorMessage = "Account name is required.")]
    // public string AccountName { get; set; } = null!;
    
    // [DataType(DataType.Password)]
    // [StringLength(100, MinimumLength = 12, ErrorMessage = "Password has to be at least 12 characters")]
    // [Required(ErrorMessage = "Password is required.")]
    // public string Password { get; set; } = null!;
    
    // Employee - one to one
    public Employee? UserEmployee { get; set; }

    public User()
    {
    }

    public User(string userName) : base(userName)
    {
    }
    
    
}