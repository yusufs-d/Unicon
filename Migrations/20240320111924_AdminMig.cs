using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unicon.Migrations
{
    /// <inheritdoc />
    public partial class AdminMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "536bb9a6-656e-4fe8-b4f8-a7a46a2ecec9", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "536bb9a6-656e-4fe8-b4f8-a7a46a2ecec9");
        }
    }
}
