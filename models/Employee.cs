using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.models;

public class Employee
{
    [Key] private int Id { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    private string EmployeeRole { get; set; }

    [DataType(DataType.PhoneNumber)]
    [StringLength(11, MinimumLength = 11)]
    private int? PhoneNumber { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    private string EmployeeName { get; set; }

    [Required] [DataType(DataType.Date)] private DateTime StartDate { get; set; }

    [DataType(DataType.Date)] private DateTime? QuiteDate { get; set; }

    // User
    private string UserId { get; set; }
    private User User { get; set; } = null!;
}