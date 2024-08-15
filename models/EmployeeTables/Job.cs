using System.ComponentModel.DataAnnotations;
using EmployeeManagement.models.JointTables;

namespace EmployeeManagement.models.EmployeeTables;

public class Job
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required] 
    [StringLength(50, ErrorMessage = "50 characters maximum")]
    public string JobName { get; set; } = null!;
    [Required] 
    [StringLength(500, ErrorMessage = "500 characters maximum")]
    public string? JobDescription { get; set; }

    public Job(string jobName, string? jobDescription)
    {
        JobName = jobName;
        JobDescription = jobDescription;
    }

    // Many-to-many Employees
    public List<Employee> Employees { get; } = [];
}