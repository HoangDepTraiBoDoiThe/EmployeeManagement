using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.models;

public class User
{
    [Key]
    private int Id { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    [Required(ErrorMessage = "User name is required.")]
    private string UserName { get; set; }
    
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 12, ErrorMessage = "Password has to be at least 12 characters")]
    [Required(ErrorMessage = "Password is required.")]
    private string Password { get; set; }
    
}