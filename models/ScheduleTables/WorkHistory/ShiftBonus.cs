﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class ShiftBonus
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public double Amount { get; set; }
    [StringLength(100)]
    public string? Reason { get; set; }
    
    // Many-to-one ShiftHistory
    public int ShiftHistoryId { get; set; }
    public ShiftHistory ShiftHistory { get; set; } = null!;
}