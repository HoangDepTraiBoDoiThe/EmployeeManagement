using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class OnLeaveHistory
{
    [Key]
    public int Id { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly FromDate { get; set; }
    [DataType(DataType.Date)]
    public DateOnly ToDate { get; set; }
    [StringLength(200)]
    public string? Reason { get; set; }
    public bool DoPunishment { get; set; } = true;
    
    // Many-to-one WorkingHistory
    public int WorkingHistoryId { get; set; }
    [ForeignKey(nameof(WorkingHistoryId))]
    public WorkingHistory WorkingHistory { get; set; } = null!;
}