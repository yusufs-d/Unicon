using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Unicon.Migrations
{
    /// <inheritdoc />
    public partial class CommentMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Entities_EntityId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EntityId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "536bb9a6-656e-4fe8-b4f8-a7a46a2ecec9");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Comments",
                newName: "RelatedID");

            migrationBuilder.AddColumn<int>(
                name: "CommentType",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e578d480-33f2-44c9-aeed-0582cd4b0d8a", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e578d480-33f2-44c9-aeed-0582cd4b0d8a");

            migrationBuilder.DropColumn(
                name: "CommentType",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "RelatedID",
                table: "Comments",
                newName: "EntityId");

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "536bb9a6-656e-4fe8-b4f8-a7a46a2ecec9", null, "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EntityId",
                table: "Comments",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Entities_EntityId",
                table: "Comments",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
