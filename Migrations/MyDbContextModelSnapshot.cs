﻿// <auto-generated />
using System;
using EmployeeManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeManagement.models.ApplicationUserTables.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EmployeeManagement.models.ApplicationUserTables.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeManagement.models.EmployeeTables.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte[]>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateOnly?>("QuitDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagement.models.EmployeeTables.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("EmployeeManagement.models.JointTables.EmployeeJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EmployeeRoleId");

                    b.ToTable("EmployeeJob");
                });

            modelBuilder.Entity("EmployeeManagement.models.JointTables.UserRole", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseShiftSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ScheduleDayId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleDayId");

                    b.ToTable("BaseShiftSchedules");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseWeakenSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("WorkScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkScheduleId");

                    b.ToTable("BaseWeakenSchedules");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseWorkSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeEmployeeRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeEmployeeRoleId");

                    b.ToTable("BaseWorkSchedules");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.OnLeave", b =>
                {
                    b.Property<int>("OnLeaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OnLeaveId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LeaveEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeaveReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LeaveStartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("WillBePunish")
                        .HasColumnType("bit");

                    b.HasKey("OnLeaveId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("OnLeaves");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.OnLeaveHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("DoPunishment")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date");

                    b.Property<string>("Reason")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateOnly>("ToDate")
                        .HasColumnType("date");

                    b.Property<int>("WorkingHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkingHistoryId");

                    b.ToTable("OnLeaveHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Reason")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ShiftHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShiftHistoryId");

                    b.ToTable("ShiftBonuses");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BaseEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BaseStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Checkin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Checkout")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShiftScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShiftScheduleId");

                    b.ToTable("ShiftHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftPenalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Reason")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ShiftHistoryId")
                        .HasColumnType("int");

                    b.Property<bool>("WillBeDeducted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ShiftHistoryId");

                    b.ToTable("ShiftPenalties");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkOverTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShiftHistoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ShiftHistoryId");

                    b.ToTable("WorkOverTimes");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingDayHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateTime")
                        .HasColumnType("date");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int?>("ShiftHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("WorkingHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShiftHistoryId");

                    b.HasIndex("WorkingHistoryId");

                    b.ToTable("WorkingDayHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseWorkScheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromTime")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("ToTime")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BaseWorkScheduleId");

                    b.ToTable("WorkingHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.WageTables.EmployeeWage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BaseSalary")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PayFrequency")
                        .HasColumnType("int");

                    b.Property<int>("WorkingHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkingHistoryId");

                    b.ToTable("EmployeeWages");
                });

            modelBuilder.Entity("EmployeeManagement.models.WageTables.MonthlyBonus", b =>
                {
                    b.Property<int>("MonthlyBonusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonthlyBonusId"));

                    b.Property<decimal>("BonusAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("BonusReason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonthlyBonusId");

                    b.ToTable("MonthlyBonuses");
                });

            modelBuilder.Entity("EmployeeManagement.models.WageTables.PayRoll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeWageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalEarnings")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeWageId");

                    b.ToTable("PayRolls");
                });

            modelBuilder.Entity("EmployeeWageMonthlyBonus", b =>
                {
                    b.Property<int>("EmployeeWagesId")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyBonusesMonthlyBonusId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeWagesId", "MonthlyBonusesMonthlyBonusId");

                    b.HasIndex("MonthlyBonusesMonthlyBonusId");

                    b.ToTable("EmployeeWageMonthlyBonus");
                });

            modelBuilder.Entity("EmployeeManagement.models.EmployeeTables.Employee", b =>
                {
                    b.HasOne("EmployeeManagement.models.ApplicationUserTables.User", "User")
                        .WithOne("UserEmployee")
                        .HasForeignKey("EmployeeManagement.models.EmployeeTables.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EmployeeManagement.models.JointTables.EmployeeJob", b =>
                {
                    b.HasOne("EmployeeManagement.models.EmployeeTables.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.models.EmployeeTables.Job", "Job")
                        .WithMany()
                        .HasForeignKey("EmployeeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("EmployeeManagement.models.JointTables.UserRole", b =>
                {
                    b.HasOne("EmployeeManagement.models.ApplicationUserTables.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.models.ApplicationUserTables.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseShiftSchedule", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.BaseWeakenSchedule", "BaseWeakenSchedule")
                        .WithMany("BaseShiftSchedule")
                        .HasForeignKey("ScheduleDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseWeakenSchedule");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseWeakenSchedule", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.BaseWorkSchedule", "BaseWorkSchedule")
                        .WithMany("ScheduleDays")
                        .HasForeignKey("WorkScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseWorkSchedule");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseWorkSchedule", b =>
                {
                    b.HasOne("EmployeeManagement.models.JointTables.EmployeeJob", "EmployeeJob")
                        .WithMany()
                        .HasForeignKey("EmployeeEmployeeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeJob");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.OnLeave", b =>
                {
                    b.HasOne("EmployeeManagement.models.EmployeeTables.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.OnLeaveHistory", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingHistory", "WorkingHistory")
                        .WithMany("OnLeaveHistories")
                        .HasForeignKey("WorkingHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkingHistory");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftBonus", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftHistory", "ShiftHistory")
                        .WithMany("ShiftBonuses")
                        .HasForeignKey("ShiftHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShiftHistory");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftHistory", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.BaseShiftSchedule", "BaseShiftSchedule")
                        .WithMany()
                        .HasForeignKey("ShiftScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseShiftSchedule");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftPenalty", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftHistory", "ShiftHistory")
                        .WithMany("ShiftPenalties")
                        .HasForeignKey("ShiftHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShiftHistory");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkOverTime", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftHistory", "ShiftHistory")
                        .WithMany("WorkOverTimes")
                        .HasForeignKey("ShiftHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShiftHistory");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingDayHistory", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftHistory", null)
                        .WithMany("WorkingDayHistories")
                        .HasForeignKey("ShiftHistoryId");

                    b.HasOne("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingHistory", "WorkingHistory")
                        .WithMany("WorkingDayHistories")
                        .HasForeignKey("WorkingHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkingHistory");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingHistory", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.BaseWorkSchedule", "WorkSchedule")
                        .WithMany()
                        .HasForeignKey("BaseWorkScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkSchedule");
                });

            modelBuilder.Entity("EmployeeManagement.models.WageTables.EmployeeWage", b =>
                {
                    b.HasOne("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingHistory", "WorkingHistory")
                        .WithMany()
                        .HasForeignKey("WorkingHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkingHistory");
                });

            modelBuilder.Entity("EmployeeManagement.models.WageTables.PayRoll", b =>
                {
                    b.HasOne("EmployeeManagement.models.WageTables.EmployeeWage", "EmployeeWage")
                        .WithMany("PayRolls")
                        .HasForeignKey("EmployeeWageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeWage");
                });

            modelBuilder.Entity("EmployeeWageMonthlyBonus", b =>
                {
                    b.HasOne("EmployeeManagement.models.WageTables.EmployeeWage", null)
                        .WithMany()
                        .HasForeignKey("EmployeeWagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.models.WageTables.MonthlyBonus", null)
                        .WithMany()
                        .HasForeignKey("MonthlyBonusesMonthlyBonusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeManagement.models.ApplicationUserTables.User", b =>
                {
                    b.Navigation("UserEmployee");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseWeakenSchedule", b =>
                {
                    b.Navigation("BaseShiftSchedule");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseWorkSchedule", b =>
                {
                    b.Navigation("ScheduleDays");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftHistory", b =>
                {
                    b.Navigation("ShiftBonuses");

                    b.Navigation("ShiftPenalties");

                    b.Navigation("WorkOverTimes");

                    b.Navigation("WorkingDayHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingHistory", b =>
                {
                    b.Navigation("OnLeaveHistories");

                    b.Navigation("WorkingDayHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.WageTables.EmployeeWage", b =>
                {
                    b.Navigation("PayRolls");
                });
#pragma warning restore 612, 618
        }
    }
}
