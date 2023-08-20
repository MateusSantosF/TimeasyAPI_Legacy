using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeasyAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixTimetableRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FPAInterval");

            migrationBuilder.RenameColumn(
                name: "StudentAmount",
                table: "TimetableSubjects",
                newName: "StudentsCount");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "TimetableSubjects",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "DividedCount",
                table: "TimetableSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDivided",
                table: "TimetableSubjects",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateAt",
                table: "Timetable",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndedAt",
                table: "Timetable",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Timetable",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<uint>(
                name: "Status",
                table: "Timetable",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<Guid>(
                name: "IntervalId",
                table: "FPA",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "CourseSubject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Start = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    End = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FPAId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_FPA_FPAId",
                        column: x => x.FPAId,
                        principalTable: "FPA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TimetableSubjects_CourseId",
                table: "TimetableSubjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_FPA_IntervalId",
                table: "FPA",
                column: "IntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_FPAId",
                table: "Schedule",
                column: "FPAId");

            migrationBuilder.AddForeignKey(
                name: "FK_FPA_Interval_IntervalId",
                table: "FPA",
                column: "IntervalId",
                principalTable: "Interval",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimetableSubjects_Course_CourseId",
                table: "TimetableSubjects",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FPA_Interval_IntervalId",
                table: "FPA");

            migrationBuilder.DropForeignKey(
                name: "FK_TimetableSubjects_Course_CourseId",
                table: "TimetableSubjects");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_TimetableSubjects_CourseId",
                table: "TimetableSubjects");

            migrationBuilder.DropIndex(
                name: "IX_FPA_IntervalId",
                table: "FPA");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "TimetableSubjects");

            migrationBuilder.DropColumn(
                name: "DividedCount",
                table: "TimetableSubjects");

            migrationBuilder.DropColumn(
                name: "IsDivided",
                table: "TimetableSubjects");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "IntervalId",
                table: "FPA");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "CourseSubject");

            migrationBuilder.RenameColumn(
                name: "StudentsCount",
                table: "TimetableSubjects",
                newName: "StudentAmount");

            migrationBuilder.CreateTable(
                name: "FPAInterval",
                columns: table => new
                {
                    FPAsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SchedulesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FPAInterval", x => new { x.FPAsId, x.SchedulesId });
                    table.ForeignKey(
                        name: "FK_FPAInterval_FPA_FPAsId",
                        column: x => x.FPAsId,
                        principalTable: "FPA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FPAInterval_Interval_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Interval",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FPAInterval_SchedulesId",
                table: "FPAInterval",
                column: "SchedulesId");
        }
    }
}
