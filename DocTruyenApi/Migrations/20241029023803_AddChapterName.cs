using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocTruyenApi.Migrations
{
    /// <inheritdoc />
    public partial class AddChapterName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChapterName",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterName",
                table: "Chapters");
        }
    }
}
