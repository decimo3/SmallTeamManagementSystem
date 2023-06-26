using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class inicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    re = table.Column<int>(type: "integer", nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    matricula = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    sobrenome = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    apelido = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    senha = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    funcao = table.Column<int>(type: "integer", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    escala = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.re);
                });

            migrationBuilder.CreateTable(
                name: "telefone",
                columns: table => new
                {
                    numero = table.Column<int>(type: "integer", nullable: false),
                    chip = table.Column<string>(type: "text", nullable: false),
                    imei = table.Column<int>(type: "integer", nullable: false),
                    marca = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    modelo = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefone", x => x.numero);
                });

            migrationBuilder.CreateTable(
                name: "viatura",
                columns: table => new
                {
                    placa = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    ordem = table.Column<int>(type: "integer", nullable: false),
                    marcaModelo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    chassi = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: true),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_viatura", x => x.placa);
                });

            migrationBuilder.CreateTable(
                name: "equipe",
                columns: table => new
                {
                    espelho = table.Column<int>(type: "integer", nullable: false),
                    servico = table.Column<int>(type: "integer", nullable: false),
                    dia = table.Column<DateOnly>(type: "date", nullable: false),
                    supervisorId = table.Column<int>(type: "integer", nullable: false),
                    motoristaId = table.Column<int>(type: "integer", nullable: false),
                    ajudanteId = table.Column<int>(type: "integer", nullable: false),
                    viaturaId = table.Column<string>(type: "character varying(7)", nullable: false),
                    telefoneId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipe", x => new { x.servico, x.espelho, x.dia });
                    table.ForeignKey(
                        name: "FK_equipe_funcionario_ajudanteId",
                        column: x => x.ajudanteId,
                        principalTable: "funcionario",
                        principalColumn: "re",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipe_funcionario_motoristaId",
                        column: x => x.motoristaId,
                        principalTable: "funcionario",
                        principalColumn: "re",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipe_funcionario_supervisorId",
                        column: x => x.supervisorId,
                        principalTable: "funcionario",
                        principalColumn: "re",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipe_telefone_telefoneId",
                        column: x => x.telefoneId,
                        principalTable: "telefone",
                        principalColumn: "numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipe_viatura_viaturaId",
                        column: x => x.viaturaId,
                        principalTable: "viatura",
                        principalColumn: "placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipe_ajudanteId",
                table: "equipe",
                column: "ajudanteId");

            migrationBuilder.CreateIndex(
                name: "IX_equipe_motoristaId",
                table: "equipe",
                column: "motoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_equipe_supervisorId",
                table: "equipe",
                column: "supervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_equipe_telefoneId",
                table: "equipe",
                column: "telefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_equipe_viaturaId",
                table: "equipe",
                column: "viaturaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipe");

            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "telefone");

            migrationBuilder.DropTable(
                name: "viatura");
        }
    }
}
