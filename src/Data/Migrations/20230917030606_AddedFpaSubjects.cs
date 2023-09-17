using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeasyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedFpaSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_FPA_FPAId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_FPAId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "FPAId",
                table: "Subject");

            migrationBuilder.CreateTable(
                name: "FpaSubjects",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FPAId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FpaSubjects", x => new { x.SubjectId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_FpaSubjects_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FpaSubjects_FPA_FPAId",
                        column: x => x.FPAId,
                        principalTable: "FPA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FpaSubjects_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FpaSubjects_CourseId",
                table: "FpaSubjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_FpaSubjects_FPAId",
                table: "FpaSubjects",
                column: "FPAId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FpaSubjects");

            migrationBuilder.AddColumn<Guid>(
                name: "FPAId",
                table: "Subject",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_FPAId",
                table: "Subject",
                column: "FPAId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_FPA_FPAId",
                table: "Subject",
                column: "FPAId",
                principalTable: "FPA",
                principalColumn: "Id");
        }
    }
}
