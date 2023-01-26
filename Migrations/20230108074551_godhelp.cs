﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuzzyBoxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class godhelp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Bookings");
        }
    }
}
