namespace EmployeeManagement.models.JointTables;

public class EmployeeEmployeeRole
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    
    public int EmployeeRoleId { get; set; }
    public EmployeeRole EmployeeRole { get; set; } = null!;
}