using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuzzyBoxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupans",
                columns: table => new
                {
                    CoupansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoupansName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coupanscode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coupansprice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coupanexpariedate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupans", x => x.CoupansId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupans");
        }
    }
}
