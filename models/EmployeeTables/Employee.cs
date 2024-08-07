using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.models.ApplicationUserTables;

namespace EmployeeManagement.models.EmployeeTables;

public class Employee
{
    [Key] 
    public int Id { get; set; }

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

    public byte[] ProfilePicture { get; set; } = [];
    
    // One to one User 
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    // Joint table - Many-to-many EmployeeJobs
    public List<Job> Jobs { get; } = [];
}