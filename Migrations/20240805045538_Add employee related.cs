using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class Addemployeerelated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Employees",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "QuitDate",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EmployeeWage",
                columns: table => new
                {
                    WageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayFrequency = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWage", x => x.WageId);
                    table.ForeignKey(
                        name: "FK_EmployeeWage_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBonus",
                columns: table => new
                {
                    MonthlyBonusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BonusAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BonusReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBonus", x => x.MonthlyBonusId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWageMonthlyBonus",
                columns: table => new
                {
                    EmployeeWagesWageId = table.Column<int>(type: "int", nullable: false),
                    MonthlyBonusesMonthlyBonusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWageMonthlyBonus", x => new { x.EmployeeWagesWageId, x.MonthlyBonusesMonthlyBonusId });
                    table.ForeignKey(
                        name: "FK_EmployeeWageMonthlyBonus_EmployeeWage_EmployeeWagesWageId",
                        column: x => x.EmployeeWagesWageId,
                        principalTable: "EmployeeWage",
                        principalColumn: "WageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeWageMonthlyBonus_MonthlyBonus_MonthlyBonusesMonthlyBonusId",
                        column: x => x.MonthlyBonusesMonthlyBonusId,
                        principalTable: "MonthlyBonus",
                        principalColumn: "MonthlyBonusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWage_EmployeeId",
                table: "EmployeeWage",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWageMonthlyBonus_MonthlyBonusesMonthlyBonusId",
                table: "EmployeeWageMonthlyBonus",
                column: "MonthlyBonusesMonthlyBonusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWageMonthlyBonus");

            migrationBuilder.DropTable(
                name: "EmployeeWage");

            migrationBuilder.DropTable(
                name: "MonthlyBonus");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "QuitDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Employees",
                type: "int",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
