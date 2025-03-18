using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    /// <inheritdoc />
    public partial class BaseAllenamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allenamenti",
                columns: table => new
                {
                    AllenamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAllenamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allenamenti", x => x.AllenamentoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allenamenti");
        }
    }
}
