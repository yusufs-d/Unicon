using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unicon.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoursesGiven",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "LecturePoint",
                table: "Courses",
                newName: "CoursePoint");

            migrationBuilder.RenameColumn(
                name: "LectureName",
                table: "Courses",
                newName: "CourseName");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CoursePoint",
                table: "Courses",
                newName: "LecturePoint");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Courses",
                newName: "LectureName");

            migrationBuilder.AddColumn<List<string>>(
                name: "CoursesGiven",
                table: "Instructors",
                type: "text[]",
                nullable: true);
        }
    }
}
