using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class StileLookup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StileId",
                table: "Esercizi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Stili",
                columns: table => new
                {
                    StileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stili", x => x.StileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Esercizi_StileId",
                table: "Esercizi",
                column: "StileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Esercizi_Stili_StileId",
                table: "Esercizi",
                column: "StileId",
                principalTable: "Stili",
                principalColumn: "StileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Esercizi_Stili_StileId",
                table: "Esercizi");

            migrationBuilder.DropTable(
                name: "Stili");

            migrationBuilder.DropIndex(
                name: "IX_Esercizi_StileId",
                table: "Esercizi");

            migrationBuilder.DropColumn(
                name: "StileId",
                table: "Esercizi");
        }
    }
}
