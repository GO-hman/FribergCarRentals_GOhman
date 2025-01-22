using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergCarRentals_GOhman.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameForAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Admins_AdminId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Bookings",
                newName: "AdminAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AdminId",
                table: "Bookings",
                newName: "IX_Bookings_AdminAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Admins_AdminAccountId",
                table: "Bookings",
                column: "AdminAccountId",
                principalTable: "Admins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Admins_AdminAccountId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "AdminAccountId",
                table: "Bookings",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AdminAccountId",
                table: "Bookings",
                newName: "IX_Bookings_AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Admins_AdminId",
                table: "Bookings",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }
    }
}
