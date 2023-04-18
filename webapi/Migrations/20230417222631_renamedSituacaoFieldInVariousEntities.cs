using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class renamedSituacaoFieldInVariousEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipe_telefone_telefonenumero",
                table: "equipe");

            migrationBuilder.DropIndex(
                name: "IX_equipe_telefonenumero",
                table: "equipe");

            migrationBuilder.DropColumn(
                name: "telefonenumero",
                table: "equipe");

            migrationBuilder.RenameColumn(
                name: "situacao",
                table: "viatura",
                newName: "situacaoViatura");

            migrationBuilder.RenameColumn(
                name: "situacao",
                table: "telefone",
                newName: "situacaoTelefone");

            migrationBuilder.RenameColumn(
                name: "situacao",
                table: "funcionario",
                newName: "situacaoFuncionario");

            migrationBuilder.AlterColumn<long>(
                name: "telefoneId",
                table: "equipe",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_equipe_telefoneId",
                table: "equipe",
                column: "telefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_equipe_telefone_telefoneId",
                table: "equipe",
                column: "telefoneId",
                principalTable: "telefone",
                principalColumn: "numero",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipe_telefone_telefoneId",
                table: "equipe");

            migrationBuilder.DropIndex(
                name: "IX_equipe_telefoneId",
                table: "equipe");

            migrationBuilder.RenameColumn(
                name: "situacaoViatura",
                table: "viatura",
                newName: "situacao");

            migrationBuilder.RenameColumn(
                name: "situacaoTelefone",
                table: "telefone",
                newName: "situacao");

            migrationBuilder.RenameColumn(
                name: "situacaoFuncionario",
                table: "funcionario",
                newName: "situacao");

            migrationBuilder.AlterColumn<int>(
                name: "telefoneId",
                table: "equipe",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "telefonenumero",
                table: "equipe",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_equipe_telefonenumero",
                table: "equipe",
                column: "telefonenumero");

            migrationBuilder.AddForeignKey(
                name: "FK_equipe_telefone_telefonenumero",
                table: "equipe",
                column: "telefonenumero",
                principalTable: "telefone",
                principalColumn: "numero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
