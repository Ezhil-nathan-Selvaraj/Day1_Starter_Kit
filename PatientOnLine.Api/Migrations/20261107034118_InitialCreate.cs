using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatientOnLine.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Therapies",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TherapyType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DialysateVolume = table.Column<double>(type: "float", nullable: false),
                    DwellTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    PrescriptionStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastSync = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Clinic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapies", x => x.PatientId);
                });

            migrationBuilder.InsertData(
                table: "Therapies",
                columns: new[] { "PatientId", "Clinic", "DialysateVolume", "DwellTimeMinutes", "LastSync", "PatientName", "PrescriptionStatus", "TherapyType" },
                values: new object[,]
                {
                    { "P-1001", "Fresenius - Bengaluru", 2.0, 240, new DateTime(2026, 11, 6, 12, 0, 0, 0, DateTimeKind.Utc), "Test Patient - PD", "Active", "PD" },
                    { "P-1002", "Fresenius - Berlin", 4.5, 180, new DateTime(2026, 11, 6, 12, 0, 0, 0, DateTimeKind.Utc), "Test Patient - HD", "Active", "HD" },
                    { "P-1003", "Fresenius - Munich", 2.5, 300, new DateTime(2026, 11, 6, 12, 0, 0, 0, DateTimeKind.Utc), "Test Patient - PD Home", "Active", "PD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Therapies");
        }
    }
}
