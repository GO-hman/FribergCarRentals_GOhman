using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergCarRentals_GOhman.Migrations
{
    /// <inheritdoc />
    public partial class Added_ImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Cars");
        }
    }
}
