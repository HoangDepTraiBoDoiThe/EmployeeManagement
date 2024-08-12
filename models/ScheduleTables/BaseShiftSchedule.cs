using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.ScheduleTables;

public class BaseShiftSchedule
{
    [Key]
    public string Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }
    
    // Many-to-one BaseWeakenSchedule
    public string ScheduleDayId { get; set; }
    [ForeignKey(nameof(ScheduleDayId))]
    public BaseWeakenSchedule BaseWeakenSchedule { get; set; } = null!;
}