using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unicon.Migrations
{
    /// <inheritdoc />
    public partial class Comment3Mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommentedById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentedById",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "154b9a2e-9d06-4333-9bb0-31db8642ae34");

            migrationBuilder.DropColumn(
                name: "CommentedById",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7be6d707-82c6-4345-a8a5-42d6efc37106", null, "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7be6d707-82c6-4345-a8a5-42d6efc37106");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentedById",
                table: "Comments",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "154b9a2e-9d06-4333-9bb0-31db8642ae34", null, "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentedById",
                table: "Comments",
                column: "CommentedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommentedById",
                table: "Comments",
                column: "CommentedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
