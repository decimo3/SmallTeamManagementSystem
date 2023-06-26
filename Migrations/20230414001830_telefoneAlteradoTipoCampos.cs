using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class telefoneAlteradoTipoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipe_telefone_telefoneId",
                table: "equipe");

            migrationBuilder.DropIndex(
                name: "IX_equipe_telefoneId",
                table: "equipe");

            migrationBuilder.AlterColumn<long>(
                name: "imei",
                table: "telefone",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "numero",
                table: "telefone",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "situacao",
                table: "telefone",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipe_telefone_telefonenumero",
                table: "equipe");

            migrationBuilder.DropIndex(
                name: "IX_equipe_telefonenumero",
                table: "equipe");

            migrationBuilder.DropColumn(
                name: "situacao",
                table: "telefone");

            migrationBuilder.DropColumn(
                name: "telefonenumero",
                table: "equipe");

            migrationBuilder.AlterColumn<int>(
                name: "imei",
                table: "telefone",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "numero",
                table: "telefone",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
    }
}
