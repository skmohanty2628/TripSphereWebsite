using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripSphere.Migrations
{
    /// <inheritdoc />
    public partial class AddIsBookedToTripModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "TripModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "TripModels");
        }
    }
}
