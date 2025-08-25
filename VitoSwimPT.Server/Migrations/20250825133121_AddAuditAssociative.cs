using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditAssociative : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateTime",
                table: "PianiAllenamento",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "PianiAllenamento",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateTime",
                table: "EserciziAllenamenti",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "EserciziAllenamenti",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDateTime",
                table: "PianiAllenamento");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "PianiAllenamento");

            migrationBuilder.DropColumn(
                name: "InsertDateTime",
                table: "EserciziAllenamenti");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "EserciziAllenamenti");
        }
    }
}
