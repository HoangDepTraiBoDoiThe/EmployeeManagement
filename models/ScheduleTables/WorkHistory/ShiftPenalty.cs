﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class ShiftPenalty
{
    [Key]
    public string Id { get; set; }
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }
    [StringLength(100)]
    public string? Reason { get; set; }
    public bool WillBeDeducted { get; set; } = true;

    // Many-to-one ShiftHistory
    public string ShiftHistoryId { get; set; }
    public ShiftHistory ShiftHistory { get; set; } = null!;
}