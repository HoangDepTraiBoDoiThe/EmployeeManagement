﻿// <auto-generated />
using System;
using EmployeeManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(MyIdentityDbContext))]
    [Migration("20240815164308_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeManagement.models.ApplicationUserTables.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagement.models.EmployeeTables.Job", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("EmployeeManagement.models.JointTables.EmployeeJob", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeRoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EmployeeRoleId");

                    b.ToTable("EmployeeJob");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseShiftSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ScheduleDayId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleDayId");

                    b.ToTable("BaseShiftSchedules");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseWeakenSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("WorkScheduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkScheduleId");

                    b.ToTable("BaseWeakenSchedules");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.BaseWorkSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeEmployeeRoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeEmployeeRoleId");

                    b.ToTable("BaseWorkSchedules");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.OnLeave", b =>
                {
                    b.Property<string>("OnLeaveId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId1")
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

                    b.HasIndex("EmployeeId1");

                    b.ToTable("OnLeaves");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.OnLeaveHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("DoPunishment")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date");

                    b.Property<string>("Reason")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateOnly>("ToDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkingHistoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkingHistoryId");

                    b.ToTable("OnLeaveHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftBonus", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Reason")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ShiftHistoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ShiftHistoryId");

                    b.ToTable("ShiftBonuses");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BaseEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BaseStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Checkin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Checkout")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftScheduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ShiftScheduleId");

                    b.ToTable("ShiftHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.ShiftPenalty", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Reason")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ShiftHistoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("WillBeDeducted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ShiftHistoryId");

                    b.ToTable("ShiftPenalties");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkOverTime", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftHistoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ShiftHistoryId");

                    b.ToTable("WorkOverTimes");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingDayHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("DateTime")
                        .HasColumnType("date");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("ShiftHistoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WorkingHistoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ShiftHistoryId");

                    b.HasIndex("WorkingHistoryId");

                    b.ToTable("WorkingDayHistories");
                });

            modelBuilder.Entity("EmployeeManagement.models.ScheduleTables.WorkHistory.WorkingHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BaseWorkScheduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("BaseSalary")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PayFrequency")
                        .HasColumnType("int");

                    b.Property<string>("WorkingHistoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkingHistoryId");

                    b.ToTable("EmployeeWages");
                });

            modelBuilder.Entity("EmployeeManagement.models.WageTables.MonthlyBonus", b =>
                {
                    b.Property<string>("MonthlyBonusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("BonusAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("BonusReason")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MonthlyBonusId");

                    b.ToTable("MonthlyBonuses");
                });

            modelBuilder.Entity("EmployeeManagement.models.WageTables.PayRoll", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeWageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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
                    b.Property<string>("EmployeeWagesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MonthlyBonusesMonthlyBonusId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EmployeeWagesId", "MonthlyBonusesMonthlyBonusId");

                    b.HasIndex("MonthlyBonusesMonthlyBonusId");

                    b.ToTable("EmployeeWageMonthlyBonus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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
                        .HasForeignKey("EmployeeId1")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EmployeeManagement.models.ApplicationUserTables.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EmployeeManagement.models.ApplicationUserTables.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.models.ApplicationUserTables.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EmployeeManagement.models.ApplicationUserTables.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
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
