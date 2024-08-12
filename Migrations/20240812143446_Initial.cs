using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBonuses",
                columns: table => new
                {
                    MonthlyBonusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BonusReason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBonuses", x => x.MonthlyBonusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    QuitDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeJob",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeJob_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJob_Jobs_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnLeaves",
                columns: table => new
                {
                    OnLeaveId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    LeaveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WillBePunish = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnLeaves", x => x.OnLeaveId);
                    table.ForeignKey(
                        name: "FK_OnLeaves_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseWorkSchedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeEmployeeRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseWorkSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseWorkSchedules_EmployeeJob_EmployeeEmployeeRoleId",
                        column: x => x.EmployeeEmployeeRoleId,
                        principalTable: "EmployeeJob",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseWeakenSchedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    WorkScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseWeakenSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseWeakenSchedules_BaseWorkSchedules_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "BaseWorkSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToTime = table.Column<DateOnly>(type: "date", nullable: false),
                    BaseWorkScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingHistories_BaseWorkSchedules_BaseWorkScheduleId",
                        column: x => x.BaseWorkScheduleId,
                        principalTable: "BaseWorkSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseShiftSchedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleDayId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseShiftSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseShiftSchedules_BaseWeakenSchedules_ScheduleDayId",
                        column: x => x.ScheduleDayId,
                        principalTable: "BaseWeakenSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayFrequency = table.Column<int>(type: "int", nullable: false),
                    WorkingHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWages_WorkingHistories_WorkingHistoryId",
                        column: x => x.WorkingHistoryId,
                        principalTable: "WorkingHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnLeaveHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ToDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DoPunishment = table.Column<bool>(type: "bit", nullable: false),
                    WorkingHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnLeaveHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnLeaveHistories_WorkingHistories_WorkingHistoryId",
                        column: x => x.WorkingHistoryId,
                        principalTable: "WorkingHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Checkin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checkout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftHistories_BaseShiftSchedules_ShiftScheduleId",
                        column: x => x.ShiftScheduleId,
                        principalTable: "BaseShiftSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWageMonthlyBonus",
                columns: table => new
                {
                    EmployeeWagesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MonthlyBonusesMonthlyBonusId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWageMonthlyBonus", x => new { x.EmployeeWagesId, x.MonthlyBonusesMonthlyBonusId });
                    table.ForeignKey(
                        name: "FK_EmployeeWageMonthlyBonus_EmployeeWages_EmployeeWagesId",
                        column: x => x.EmployeeWagesId,
                        principalTable: "EmployeeWages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeWageMonthlyBonus_MonthlyBonuses_MonthlyBonusesMonthlyBonusId",
                        column: x => x.MonthlyBonusesMonthlyBonusId,
                        principalTable: "MonthlyBonuses",
                        principalColumn: "MonthlyBonusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalEarnings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeWageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayRolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayRolls_EmployeeWages_EmployeeWageId",
                        column: x => x.EmployeeWageId,
                        principalTable: "EmployeeWages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftBonuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShiftHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftBonuses_ShiftHistories_ShiftHistoryId",
                        column: x => x.ShiftHistoryId,
                        principalTable: "ShiftHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftPenalties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WillBeDeducted = table.Column<bool>(type: "bit", nullable: false),
                    ShiftHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftPenalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftPenalties_ShiftHistories_ShiftHistoryId",
                        column: x => x.ShiftHistoryId,
                        principalTable: "ShiftHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingDayHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    WorkingHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShiftHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDayHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingDayHistories_ShiftHistories_ShiftHistoryId",
                        column: x => x.ShiftHistoryId,
                        principalTable: "ShiftHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingDayHistories_WorkingHistories_WorkingHistoryId",
                        column: x => x.WorkingHistoryId,
                        principalTable: "WorkingHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOverTimes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOverTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOverTimes_ShiftHistories_ShiftHistoryId",
                        column: x => x.ShiftHistoryId,
                        principalTable: "ShiftHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseShiftSchedules_ScheduleDayId",
                table: "BaseShiftSchedules",
                column: "ScheduleDayId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWeakenSchedules_WorkScheduleId",
                table: "BaseWeakenSchedules",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWorkSchedules_EmployeeEmployeeRoleId",
                table: "BaseWorkSchedules",
                column: "EmployeeEmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJob_EmployeeId",
                table: "EmployeeJob",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJob_EmployeeRoleId",
                table: "EmployeeJob",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWageMonthlyBonus_MonthlyBonusesMonthlyBonusId",
                table: "EmployeeWageMonthlyBonus",
                column: "MonthlyBonusesMonthlyBonusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWages_WorkingHistoryId",
                table: "EmployeeWages",
                column: "WorkingHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnLeaveHistories_WorkingHistoryId",
                table: "OnLeaveHistories",
                column: "WorkingHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnLeaves_EmployeeId",
                table: "OnLeaves",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayRolls_EmployeeWageId",
                table: "PayRolls",
                column: "EmployeeWageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftBonuses_ShiftHistoryId",
                table: "ShiftBonuses",
                column: "ShiftHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftHistories_ShiftScheduleId",
                table: "ShiftHistories",
                column: "ShiftScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPenalties_ShiftHistoryId",
                table: "ShiftPenalties",
                column: "ShiftHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDayHistories_ShiftHistoryId",
                table: "WorkingDayHistories",
                column: "ShiftHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDayHistories_WorkingHistoryId",
                table: "WorkingDayHistories",
                column: "WorkingHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHistories_BaseWorkScheduleId",
                table: "WorkingHistories",
                column: "BaseWorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOverTimes_ShiftHistoryId",
                table: "WorkOverTimes",
                column: "ShiftHistoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmployeeWageMonthlyBonus");

            migrationBuilder.DropTable(
                name: "OnLeaveHistories");

            migrationBuilder.DropTable(
                name: "OnLeaves");

            migrationBuilder.DropTable(
                name: "PayRolls");

            migrationBuilder.DropTable(
                name: "ShiftBonuses");

            migrationBuilder.DropTable(
                name: "ShiftPenalties");

            migrationBuilder.DropTable(
                name: "WorkingDayHistories");

            migrationBuilder.DropTable(
                name: "WorkOverTimes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MonthlyBonuses");

            migrationBuilder.DropTable(
                name: "EmployeeWages");

            migrationBuilder.DropTable(
                name: "ShiftHistories");

            migrationBuilder.DropTable(
                name: "WorkingHistories");

            migrationBuilder.DropTable(
                name: "BaseShiftSchedules");

            migrationBuilder.DropTable(
                name: "BaseWeakenSchedules");

            migrationBuilder.DropTable(
                name: "BaseWorkSchedules");

            migrationBuilder.DropTable(
                name: "EmployeeJob");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
