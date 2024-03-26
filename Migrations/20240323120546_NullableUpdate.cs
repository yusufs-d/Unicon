using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unicon.Migrations
{
    /// <inheritdoc />
    public partial class NullableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88818d1f-556e-4187-ae58-8983bc3c0dad");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Courses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d74f9f86-acb2-4dfc-bc8f-b1c8f4451dd5", null, "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d74f9f86-acb2-4dfc-bc8f-b1c8f4451dd5");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88818d1f-556e-4187-ae58-8983bc3c0dad", null, "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
