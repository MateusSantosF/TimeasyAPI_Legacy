using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeasyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedTeachersInTimetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "FPA");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomTypeId",
                table: "Room",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "TeacherTimetable",
                columns: table => new
                {
                    TeachersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TimetablesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTimetable", x => new { x.TeachersId, x.TimetablesId });
                    table.ForeignKey(
                        name: "FK_TeacherTimetable_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherTimetable_Timetable_TimetablesId",
                        column: x => x.TimetablesId,
                        principalTable: "Timetable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTimetable_TimetablesId",
                table: "TeacherTimetable",
                column: "TimetablesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "TeacherTimetable");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomTypeId",
                table: "Room",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "FPA",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
