using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class tes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Entidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor = table.Column<string>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Ano = table.Column<string>(nullable: false),
                    Edicao = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: false),
                    Editora = table.Column<string>(nullable: false),
                    Paginas = table.Column<string>(nullable: false),
                    Isbn = table.Column<string>(nullable: false),
                    Issn = table.Column<string>(nullable: false),
                    InstituicaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obra_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obra_InstituicaoId",
                table: "Obra",
                column: "InstituicaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obra");

            migrationBuilder.DropTable(
                name: "Instituicao");
        }
    }
}
