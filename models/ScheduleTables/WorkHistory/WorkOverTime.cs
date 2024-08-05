namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class WorkOverTime
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }

    // Many-to-one ShiftHistory
    public int ShiftHistoryId { get; set; }
    public ShiftHistory ShiftHistory { get; set; } = null!;
}