using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace EmployeeManagement.models;

public class Employee
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string EmployeeRole { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [StringLength(11, MinimumLength = 11)]
    public int? PhoneNumber { get; set; }

    [Required]
    [StringLength(100)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string EmployeeName { get; set; } = null!;

    [Required] [DataType(DataType.Date)] private DateTime StartDate { get; set; }
    [DataType(DataType.Date)] private DateTime? QuiteDate { get; set; }
    public Blob ProfilePicture { get; set; }

    
    // User - one to one
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public Employee()
    {
    }
    
    public Employee(int id, string employeeRole, int? phoneNumber, string employeeName, DateTime startDate, DateTime? quiteDate, int userId, User user)
    {
        Id = id;
        EmployeeRole = employeeRole;
        PhoneNumber = phoneNumber;
        EmployeeName = employeeName;
        StartDate = startDate;
        QuiteDate = quiteDate;
        UserId = userId;
        User = user;
    }
    
    public Employee(string employeeRole, int? phoneNumber, string employeeName, DateTime startDate, DateTime? quiteDate, int userId, User user)
    {
        EmployeeRole = employeeRole;
        PhoneNumber = phoneNumber;
        EmployeeName = employeeName;
        StartDate = startDate;
        QuiteDate = quiteDate;
        UserId = userId;
        User = user;
    }
}