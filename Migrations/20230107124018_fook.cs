using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuzzyBoxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foodname",
                table: "Foodorders");

            migrationBuilder.DropColumn(
                name: "Foodprice",
                table: "Foodorders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foodname",
                table: "Foodorders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Foodprice",
                table: "Foodorders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
