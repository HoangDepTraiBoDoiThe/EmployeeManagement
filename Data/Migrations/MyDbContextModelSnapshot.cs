﻿// <auto-generated />
using System;
using EmployeeManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.Data.Migrations
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

            modelBuilder.Entity("EmployeeManagement.models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeRole")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<byte[]>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("QuitDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagement.models.EmployeeWage", b =>
                {
                    b.Property<int>("WageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WageId"));

                    b.Property<decimal>("BaseSalary")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("PayFrequency")
                        .HasColumnType("int");

                    b.HasKey("WageId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeWage");
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

            modelBuilder.Entity("EmployeeManagement.models.MonthlyBonus", b =>
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

                    b.ToTable("MonthlyBonus");
                });

            modelBuilder.Entity("EmployeeManagement.models.Role", b =>
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

            modelBuilder.Entity("EmployeeManagement.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("EmployeeWageMonthlyBonus", b =>
                {
                    b.Property<int>("EmployeeWagesWageId")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyBonusesMonthlyBonusId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeWagesWageId", "MonthlyBonusesMonthlyBonusId");

                    b.HasIndex("MonthlyBonusesMonthlyBonusId");

                    b.ToTable("EmployeeWageMonthlyBonus");
                });

            modelBuilder.Entity("EmployeeManagement.models.Employee", b =>
                {
                    b.HasOne("EmployeeManagement.models.User", "User")
                        .WithOne("UserEmployee")
                        .HasForeignKey("EmployeeManagement.models.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EmployeeManagement.models.EmployeeWage", b =>
                {
                    b.HasOne("EmployeeManagement.models.Employee", "Employee")
                        .WithMany("Wages")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeManagement.models.JointTables.UserRole", b =>
                {
                    b.HasOne("EmployeeManagement.models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeWageMonthlyBonus", b =>
                {
                    b.HasOne("EmployeeManagement.models.EmployeeWage", null)
                        .WithMany()
                        .HasForeignKey("EmployeeWagesWageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.models.MonthlyBonus", null)
                        .WithMany()
                        .HasForeignKey("MonthlyBonusesMonthlyBonusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeManagement.models.Employee", b =>
                {
                    b.Navigation("Wages");
                });

            modelBuilder.Entity("EmployeeManagement.models.User", b =>
                {
                    b.Navigation("UserEmployee");
                });
#pragma warning restore 612, 618
        }
    }
}
