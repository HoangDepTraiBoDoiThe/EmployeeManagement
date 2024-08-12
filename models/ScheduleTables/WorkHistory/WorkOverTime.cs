namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class WorkOverTime
{
    public string Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }

    // Many-to-one ShiftHistory
    public string ShiftHistoryId { get; set; }
    public ShiftHistory ShiftHistory { get; set; } = null!;
}