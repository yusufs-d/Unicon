using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unicon.Migrations
{
    /// <inheritdoc />
    public partial class CommentMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e578d480-33f2-44c9-aeed-0582cd4b0d8a");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "154b9a2e-9d06-4333-9bb0-31db8642ae34", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "154b9a2e-9d06-4333-9bb0-31db8642ae34");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e578d480-33f2-44c9-aeed-0582cd4b0d8a", null, "Admin", "ADMIN" });
        }
    }
}
