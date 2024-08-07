using System.ComponentModel.DataAnnotations;
using EmployeeManagement.models.EmployeeTables;

namespace EmployeeManagement.models.ApplicationUserTables;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    [Required(ErrorMessage = "User name is required.")]
    public string UserName { get; set; } = null!;
    
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 12, ErrorMessage = "Password has to be at least 12 characters")]
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = null!;
    
    // Employee - one to one
    public Employee? UserEmployee { get; set; }
    
    // Role
    public List<Role> Roles { get; } = [];

    public User()
    {
    }
    public User(string userName, string password, Employee? userEmployee)
    {
        UserName = userName;
        Password = password;
        UserEmployee = userEmployee;
    }
    public User(int id, string userName, string password, Employee? userEmployee)
    {
        Id = id;
        UserName = userName;
        Password = password;
        UserEmployee = userEmployee;
    }
}