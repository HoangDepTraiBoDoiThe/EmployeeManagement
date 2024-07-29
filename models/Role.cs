using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.models;

public class Role
{
    [Key]
    private int Id { get; set; }
    
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(30)]
    private string RoleName { get; set; }
}