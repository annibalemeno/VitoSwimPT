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
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DatePlanned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDone = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoneBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_AllenamentiUtente_Utenti_DoneBy",
                        column: x => x.DoneBy,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllenamentiUtente_AllenamentoId",
                table: "AllenamentiUtente",
                column: "AllenamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AllenamentiUtente_DoneBy",
                table: "AllenamentiUtente",
                column: "DoneBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllenamentiUtente");
        }
    }
}
