using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class PianiAllenamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PianiAllenamento",
                columns: table => new
                {
                    PianoId = table.Column<int>(type: "int", nullable: false),
                    AllenamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PianiAllenamento", x => new { x.PianoId, x.AllenamentoId });
                    table.ForeignKey(
                        name: "FK_PianiAllenamento_Allenamenti_AllenamentoId",
                        column: x => x.AllenamentoId,
                        principalTable: "Allenamenti",
                        principalColumn: "AllenamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PianiAllenamento_Piani_PianoId",
                        column: x => x.PianoId,
                        principalTable: "Piani",
                        principalColumn: "PianoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PianiAllenamento_AllenamentoId",
                table: "PianiAllenamento",
                column: "AllenamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PianiAllenamento");
        }
    }
}
