using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class StileStringRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stile",
                table: "Esercizi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stile",
                table: "Esercizi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
