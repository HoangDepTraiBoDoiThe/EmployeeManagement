using EmployeeManagement.Constants;
using EmployeeManagement.models;
using EmployeeManagement.models.ApplicationUserTables;
using EmployeeManagement.models.EmployeeTables;
using EmployeeManagement.models.JointTables;
using EmployeeManagement.models.ScheduleTables;
using EmployeeManagement.models.ScheduleTables.WorkHistory;
using EmployeeManagement.models.WageTables;
using Microsoft.EntityFrameworkCore;
using EmployeeWage = EmployeeManagement.models.WageTables.EmployeeWage;

namespace EmployeeManagement.Context;

public class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
   
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
        OnModelCreatingPartial(modelBuilder);
    }

    void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
            .HasMany(e => e.Users)
            .WithMany(e => e.Roles)
            .UsingEntity<UserRole>();
        
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