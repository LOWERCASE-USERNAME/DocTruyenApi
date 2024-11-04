using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocTruyenApi.Migrations
{
    public partial class TestApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadHistories_Chapters_ChapterId",
                table: "ReadHistories");

            migrationBuilder.AlterColumn<int>(
                name: "ChapterId",
                table: "ReadHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadHistories_Chapters_ChapterId",
                table: "ReadHistories",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "ChapterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadHistories_Chapters_ChapterId",
                table: "ReadHistories");

            migrationBuilder.AlterColumn<int>(
                name: "ChapterId",
                table: "ReadHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadHistories_Chapters_ChapterId",
                table: "ReadHistories",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "ChapterId");
        }
    }
}
