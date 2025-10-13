using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class PianoStartEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Piani",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Piani",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Piani");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Piani");
        }
    }
}
