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
    public string? PhoneNumber { get; set; }

    [Required]
    [StringLength(100)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string EmployeeName { get; set; } = null!;

    [Required] 
    [DataType(DataType.Date)] 
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)] 
    public DateTime? QuitDate { get; set; }
    public Blob ProfilePicture { get; set; }
    
    // User - one to one
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    // EmployeeWage - one to many
    public ICollection<EmployeeWage> Wages { get;} = new List<EmployeeWage>();
    
    public Employee()
    {
    }
    
    public Employee(int id, string employeeRole, string? phoneNumber, string employeeName, DateTime startDate, DateTime? quitDate, int userId, User user)
    {
        Id = id;
        EmployeeRole = employeeRole;
        PhoneNumber = phoneNumber;
        EmployeeName = employeeName;
        StartDate = startDate;
        QuitDate = quitDate;
        UserId = userId;
        User = user;
    }
    
    public Employee(string employeeRole, string? phoneNumber, string employeeName, DateTime startDate, DateTime? quitDate, int userId, User user)
    {
        EmployeeRole = employeeRole;
        PhoneNumber = phoneNumber;
        EmployeeName = employeeName;
        StartDate = startDate;
        QuitDate = quitDate;
        UserId = userId;
        User = user;
    }
}