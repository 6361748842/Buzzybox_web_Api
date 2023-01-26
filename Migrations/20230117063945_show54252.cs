using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuzzyBoxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class show54252 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bookingtime",
                table: "Bookings",
                newName: "Bookingstarttime");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingEndtime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingEndtime",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Bookingstarttime",
                table: "Bookings",
                newName: "Bookingtime");
        }
    }
}
