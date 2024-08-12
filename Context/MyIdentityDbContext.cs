using EmployeeManagement.models.ApplicationUserTables;
using EmployeeManagement.models.EmployeeTables;
using EmployeeManagement.models.JointTables;
using EmployeeManagement.models.ScheduleTables;
using EmployeeManagement.models.ScheduleTables.WorkHistory;
using EmployeeManagement.models.WageTables;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Context;

public class MyIdentityDbContext : IdentityDbContext<User>
{
    public MyIdentityDbContext()
    {
    }

    public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Job> Jobs { get; set; }
    
    public DbSet<OnLeave> OnLeaves { get; set; }
    public DbSet<BaseShiftSchedule> BaseShiftSchedules { get; set; }
    public DbSet<BaseWeakenSchedule> BaseWeakenSchedules { get; set; }
    public DbSet<BaseWorkSchedule> BaseWorkSchedules { get; set; }
    
    public DbSet<WorkingHistory> WorkingHistories { get; set; }
    public DbSet<OnLeaveHistory> OnLeaveHistories { get; set; }
    public DbSet<WorkingDayHistory> WorkingDayHistories { get; set; }
    public DbSet<ShiftBonus> ShiftBonuses { get; set; }
    public DbSet<ShiftHistory> ShiftHistories { get; set; }
    public DbSet<ShiftPenalty> ShiftPenalties { get; set; }
    public DbSet<WorkOverTime> WorkOverTimes { get; set; }
    
    public DbSet<PayRoll> PayRolls { get; set; }
    public DbSet<EmployeeWage> EmployeeWages { get; set; }
    public DbSet<MonthlyBonus> MonthlyBonuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.User)
            .WithOne(u => u.UserEmployee)
            .HasForeignKey<Employee>(employee => employee.UserId);

        modelBuilder.Entity<EmployeeWage>()
            .HasMany(emp => emp.MonthlyBonuses)
            .WithMany(b => (IEnumerable<EmployeeWage>)b.EmployeeWages);

        modelBuilder.Entity<Employee>().HasMany(emp => emp.Jobs).WithMany(job => job.Employees).UsingEntity<EmployeeJob>();
    }
    
    public async Task<T> AddToDatabase<T >(T entityDataToAdd)
    {
        if (entityDataToAdd == null) throw new ArgumentNullException(nameof(entityDataToAdd));
        var createdEntity = Add(entityDataToAdd);
        await SaveChangesAsync();
        return (T)createdEntity.Entity;
    }
}