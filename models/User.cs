using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models;

public class User
{
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private int Id { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    [Required(ErrorMessage = "User name is required.")]
    private string UserName { get; set; } = null!;
    
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 12, ErrorMessage = "Password has to be at least 12 characters")]
    [Required(ErrorMessage = "Password is required.")]
    private string Password { get; set; } = null!;
    
    // Employee - one to one
    private Employee? UserEmployee { get; set; }
    
    // Role
    private List<Role> Roles { get; } = [];
}