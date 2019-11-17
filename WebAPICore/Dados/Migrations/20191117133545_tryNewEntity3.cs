using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class tryNewEntity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obra_Instituicao_instituicaoId",
                table: "Obra");

            migrationBuilder.RenameColumn(
                name: "instituicaoId",
                table: "Obra",
                newName: "InstituicaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Obra_instituicaoId",
                table: "Obra",
                newName: "IX_Obra_InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obra_Instituicao_InstituicaoId",
                table: "Obra",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obra_Instituicao_InstituicaoId",
                table: "Obra");

            migrationBuilder.RenameColumn(
                name: "InstituicaoId",
                table: "Obra",
                newName: "instituicaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Obra_InstituicaoId",
                table: "Obra",
                newName: "IX_Obra_instituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obra_Instituicao_instituicaoId",
                table: "Obra",
                column: "instituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
