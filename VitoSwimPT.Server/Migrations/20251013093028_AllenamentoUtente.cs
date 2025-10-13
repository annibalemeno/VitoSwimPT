using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class AllenamentoUtente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllenamentiUtente",
                columns: table => new
                {
                    AllenamentoUtenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllenamentoId = table.Column<int>(type: "int", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePlanned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDone = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllenamentiUtente", x => x.AllenamentoUtenteId);
                    table.ForeignKey(
                        name: "FK_AllenamentiUtente_Allenamenti_AllenamentoId",
                        column: x => x.AllenamentoId,
                        principalTable: "Allenamenti",
                        principalColumn: "AllenamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllenamentiUtente_AllenamentoId",
                table: "AllenamentiUtente",
                column: "AllenamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllenamentiUtente");
        }
    }
}
