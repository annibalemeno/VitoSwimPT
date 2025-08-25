using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditAllenamentoPianoStile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateTime",
                table: "Stili",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Stili",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateTime",
                table: "Piani",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Piani",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateTime",
                table: "Allenamenti",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Allenamenti",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDateTime",
                table: "Stili");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Stili");

            migrationBuilder.DropColumn(
                name: "InsertDateTime",
                table: "Piani");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Piani");

            migrationBuilder.DropColumn(
                name: "InsertDateTime",
                table: "Allenamenti");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Allenamenti");
        }
    }
}
