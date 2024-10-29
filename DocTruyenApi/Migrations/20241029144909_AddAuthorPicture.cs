using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocTruyenApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "Authors");
        }
    }
}
