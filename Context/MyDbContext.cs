using EmployeeManagement.models;
using EmployeeManagement.models.JointTables;
using Microsoft.EntityFrameworkCore;

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

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Dev");

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
            .IsRequired(true)
            .HasForeignKey<Employee>(employee => employee.UserId);

        modelBuilder.Entity<EmployeeWage>()
            .HasMany(emp => emp.MonthlyBonuses)
            .WithMany(mon => mon.EmployeeWages);
    }
}