using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class EsercizioAllenamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EserciziAllenamenti",
                columns: table => new
                {
                    EsercizioId = table.Column<int>(type: "int", nullable: false),
                    AllenamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EserciziAllenamenti", x => new { x.EsercizioId, x.AllenamentoId });
                    table.ForeignKey(
                        name: "FK_EserciziAllenamenti_Allenamenti_AllenamentoId",
                        column: x => x.AllenamentoId,
                        principalTable: "Allenamenti",
                        principalColumn: "AllenamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EserciziAllenamenti_Esercizi_EsercizioId",
                        column: x => x.EsercizioId,
                        principalTable: "Esercizi",
                        principalColumn: "EsercizioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EserciziAllenamenti_AllenamentoId",
                table: "EserciziAllenamenti",
                column: "AllenamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EserciziAllenamenti");
        }
    }
}
