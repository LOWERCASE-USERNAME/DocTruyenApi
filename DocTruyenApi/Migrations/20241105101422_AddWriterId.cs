using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocTruyenApi.Migrations
{
    public partial class AddWriterId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_WriterId",
                table: "Books",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_WriterId",
                table: "Books",
                column: "WriterId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_WriterId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_WriterId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Books");
        }
    }
}
