using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSistemaEscolarAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConstrucaoDoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoInstituicao = table.Column<int>(type: "int", nullable: false),
                    QtdAlunos = table.Column<int>(type: "int", nullable: false),
                    QtdTurmas = table.Column<int>(type: "int", nullable: false),
                    QtdCursos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    IdMateria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeMateria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessorDaMateria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.IdMateria);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    IdTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoTurma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.IdTurma);
                    table.ForeignKey(
                        name: "FK_Turma_Instituicao_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicao",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    IdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NomeAluno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Aluno_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaXTurma",
                columns: table => new
                {
                    IdMateriaTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMateria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaXTurma", x => x.IdMateriaTurma);
                    table.ForeignKey(
                        name: "FK_MateriaXTurma_Materia_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Materia",
                        principalColumn: "IdMateria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaXTurma_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdTurma",
                table: "Aluno",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaXTurma_IdMateria",
                table: "MateriaXTurma",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaXTurma_IdTurma",
                table: "MateriaXTurma",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdInstituicao",
                table: "Turma",
                column: "IdInstituicao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "MateriaXTurma");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Instituicao");
        }
    }
}
