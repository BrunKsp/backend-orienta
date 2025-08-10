using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orienta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "orienta");

            migrationBuilder.CreateTable(
                name: "questionario",
                schema: "orienta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    professor_slug = table.Column<string>(type: "varchar(100)", nullable: true),
                    criado_por = table.Column<int>(type: "integer", nullable: false),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "orienta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    foto = table.Column<string>(type: "varchar(100)", nullable: true),
                    tipo_usuario = table.Column<int>(type: "integer", nullable: false),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "perguntas",
                schema: "orienta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    questionario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    enunciado = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    resposta_esperada = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perguntas", x => x.id);
                    table.ForeignKey(
                        name: "FK_perguntas_questionario_questionario_id",
                        column: x => x.questionario_id,
                        principalSchema: "orienta",
                        principalTable: "questionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alunos",
                schema: "orienta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos", x => x.id);
                    table.ForeignKey(
                        name: "FK_alunos_usuarios_id",
                        column: x => x.id,
                        principalSchema: "orienta",
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professores",
                schema: "orienta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professores", x => x.id);
                    table.ForeignKey(
                        name: "FK_professores_usuarios_id",
                        column: x => x.id,
                        principalSchema: "orienta",
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alternativas",
                schema: "orienta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    texto = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    correta = table.Column<bool>(type: "boolean", nullable: false),
                    pergunta_id = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alternativas", x => x.id);
                    table.ForeignKey(
                        name: "FK_alternativas_perguntas_pergunta_id",
                        column: x => x.pergunta_id,
                        principalSchema: "orienta",
                        principalTable: "perguntas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "respostas",
                schema: "orienta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    aluno_id = table.Column<Guid>(type: "uuid", nullable: false),
                    questioario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respostas", x => x.id);
                    table.ForeignKey(
                        name: "FK_respostas_alunos_aluno_id",
                        column: x => x.aluno_id,
                        principalSchema: "orienta",
                        principalTable: "alunos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_respostas_questionario_questioario_id",
                        column: x => x.questioario_id,
                        principalSchema: "orienta",
                        principalTable: "questionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "respostas_perguntas",
                schema: "orienta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    resposta_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pergunta_id = table.Column<Guid>(type: "uuid", nullable: false),
                    resposta_aluno = table.Column<string>(type: "varchar(100)", nullable: false),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respostas_perguntas", x => x.id);
                    table.ForeignKey(
                        name: "FK_respostas_perguntas_perguntas_pergunta_id",
                        column: x => x.pergunta_id,
                        principalSchema: "orienta",
                        principalTable: "perguntas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_respostas_perguntas_respostas_resposta_id",
                        column: x => x.resposta_id,
                        principalSchema: "orienta",
                        principalTable: "respostas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alternativas_pergunta_id",
                schema: "orienta",
                table: "alternativas",
                column: "pergunta_id");

            migrationBuilder.CreateIndex(
                name: "IX_alternativas_slug",
                schema: "orienta",
                table: "alternativas",
                column: "slug");

            migrationBuilder.CreateIndex(
                name: "IX_perguntas_questionario_id",
                schema: "orienta",
                table: "perguntas",
                column: "questionario_id");

            migrationBuilder.CreateIndex(
                name: "IX_perguntas_slug",
                schema: "orienta",
                table: "perguntas",
                column: "slug");

            migrationBuilder.CreateIndex(
                name: "IX_questionario_slug",
                schema: "orienta",
                table: "questionario",
                column: "slug");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_aluno_id",
                schema: "orienta",
                table: "respostas",
                column: "aluno_id");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_questioario_id",
                schema: "orienta",
                table: "respostas",
                column: "questioario_id");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_slug",
                schema: "orienta",
                table: "respostas",
                column: "slug");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_perguntas_pergunta_id",
                schema: "orienta",
                table: "respostas_perguntas",
                column: "pergunta_id");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_perguntas_resposta_id",
                schema: "orienta",
                table: "respostas_perguntas",
                column: "resposta_id");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_perguntas_slug",
                schema: "orienta",
                table: "respostas_perguntas",
                column: "slug");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_slug",
                schema: "orienta",
                table: "usuarios",
                column: "slug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alternativas",
                schema: "orienta");

            migrationBuilder.DropTable(
                name: "professores",
                schema: "orienta");

            migrationBuilder.DropTable(
                name: "respostas_perguntas",
                schema: "orienta");

            migrationBuilder.DropTable(
                name: "perguntas",
                schema: "orienta");

            migrationBuilder.DropTable(
                name: "respostas",
                schema: "orienta");

            migrationBuilder.DropTable(
                name: "alunos",
                schema: "orienta");

            migrationBuilder.DropTable(
                name: "questionario",
                schema: "orienta");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "orienta");
        }
    }
}
