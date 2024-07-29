using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models;

public class Employee
{
    [Key] 
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private int Id { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    private string EmployeeRole { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [StringLength(11, MinimumLength = 11)]
    private int? PhoneNumber { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    private string EmployeeName { get; set; } = null!;

    [Required] [DataType(DataType.Date)] private DateTime StartDate { get; set; }
    [DataType(DataType.Date)] private DateTime? QuiteDate { get; set; }

    // User - one to one
    private string UserId { get; set; } = null!;
    private User User { get; set; } = null!;
    
    
}