using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergCarRentals_GOhman.Migrations
{
    /// <inheritdoc />
    public partial class MoreBookingControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Consumed",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consumed",
                table: "Bookings");
        }
    }
}
