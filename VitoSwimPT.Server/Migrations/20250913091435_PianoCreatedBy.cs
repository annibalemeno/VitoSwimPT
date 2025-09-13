using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class PianoCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Createdby",
                table: "Piani",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Piani_Createdby",
                table: "Piani",
                column: "Createdby");

            migrationBuilder.AddForeignKey(
                name: "FK_Piani_Utenti_Createdby",
                table: "Piani",
                column: "Createdby",
                principalTable: "Utenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piani_Utenti_Createdby",
                table: "Piani");

            migrationBuilder.DropIndex(
                name: "IX_Piani_Createdby",
                table: "Piani");

            migrationBuilder.DropColumn(
                name: "Createdby",
                table: "Piani");
        }
    }
}
