using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSistemaEscolarAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoUnidade = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdTurmas = table.Column<int>(type: "int", nullable: false),
                    QtdAlunos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.EscolaId);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    MateriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeMateria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorDaMateria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdTurmasMatriculadas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoDaTurma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdAlunos = table.Column<int>(type: "int", nullable: false),
                    Escola = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.TurmaId);
                    table.ForeignKey(
                        name: "FK_Turmas_Escolas_Escola",
                        column: x => x.Escola,
                        principalTable: "Escolas",
                        principalColumn: "EscolaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    NomeAluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Escola = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmasTurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Alunos_Escolas_Escola",
                        column: x => x.Escola,
                        principalTable: "Escolas",
                        principalColumn: "EscolaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmasTurmaId",
                        column: x => x.TurmasTurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId");
                });

            migrationBuilder.CreateTable(
                name: "MateriasDasTurmas",
                columns: table => new
                {
                    MateriaDaTurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Turma = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Materia = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasDasTurmas", x => x.MateriaDaTurmaId);
                    table.ForeignKey(
                        name: "FK_MateriasDasTurmas_Materias_Materia",
                        column: x => x.Materia,
                        principalTable: "Materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriasDasTurmas_Turmas_Turma",
                        column: x => x.Turma,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Escola",
                table: "Alunos",
                column: "Escola");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmasTurmaId",
                table: "Alunos",
                column: "TurmasTurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasDasTurmas_Materia",
                table: "MateriasDasTurmas",
                column: "Materia");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasDasTurmas_Turma",
                table: "MateriasDasTurmas",
                column: "Turma");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_Escola",
                table: "Turmas",
                column: "Escola");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "MateriasDasTurmas");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Escolas");
        }
    }
}
