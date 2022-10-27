using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalibrationTracking.Infrastructure.Migrations
{
    public partial class UpdatedCalibrationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calibrations_Devices_DeviceId",
                table: "Calibrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Calibrations_Employees_EmployeeId",
                table: "Calibrations");

            migrationBuilder.DropIndex(
                name: "IX_Calibrations_DeviceId",
                table: "Calibrations");

            migrationBuilder.DropIndex(
                name: "IX_Calibrations_EmployeeId",
                table: "Calibrations");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Calibrations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Calibrations");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Calibrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Calibrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "Calibrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "Calibrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Calibrations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Calibrations");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "Calibrations");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "Calibrations");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "Calibrations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Calibrations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calibrations_DeviceId",
                table: "Calibrations",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Calibrations_EmployeeId",
                table: "Calibrations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calibrations_Devices_DeviceId",
                table: "Calibrations",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calibrations_Employees_EmployeeId",
                table: "Calibrations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
