using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class tryNewEntity4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obra_Instituicao_InstituicaoId",
                table: "Obra");

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Obra",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Obra_Instituicao_InstituicaoId",
                table: "Obra",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obra_Instituicao_InstituicaoId",
                table: "Obra");

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Obra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Obra_Instituicao_InstituicaoId",
                table: "Obra",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
