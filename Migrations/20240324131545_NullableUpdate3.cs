using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unicon.Migrations
{
    /// <inheritdoc />
    public partial class NullableUpdate3 : Migration
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
                keyValue: "f5177d05-1cef-4c2f-b8c1-6c1a7d9adeaa");

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
                values: new object[] { "041d5726-2176-45bc-a0b0-40a8405934f8", null, "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
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
                keyValue: "041d5726-2176-45bc-a0b0-40a8405934f8");

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
                values: new object[] { "f5177d05-1cef-4c2f-b8c1-6c1a7d9adeaa", null, "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId");
        }
    }
}
