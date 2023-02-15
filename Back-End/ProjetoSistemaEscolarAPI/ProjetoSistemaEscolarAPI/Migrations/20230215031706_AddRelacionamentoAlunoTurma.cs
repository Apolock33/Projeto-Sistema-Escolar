using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSistemaEscolarAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentoAlunoTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmasTurmaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Escolas_Escola",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_Escola",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmasTurmaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Escola",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "TurmasTurmaId",
                table: "Alunos");

            migrationBuilder.AddColumn<Guid>(
                name: "EscolasEscolaId",
                table: "Turmas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Turma",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EscolasEscolaId",
                table: "Turmas",
                column: "EscolasEscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Turma",
                table: "Alunos",
                column: "Turma");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_Turma",
                table: "Alunos",
                column: "Turma",
                principalTable: "Turmas",
                principalColumn: "TurmaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Escolas_EscolasEscolaId",
                table: "Turmas",
                column: "EscolasEscolaId",
                principalTable: "Escolas",
                principalColumn: "EscolaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_Turma",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Escolas_EscolasEscolaId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_EscolasEscolaId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_Turma",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "EscolasEscolaId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "Turma",
                table: "Alunos");

            migrationBuilder.AddColumn<Guid>(
                name: "Escola",
                table: "Turmas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TurmasTurmaId",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_Escola",
                table: "Turmas",
                column: "Escola");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmasTurmaId",
                table: "Alunos",
                column: "TurmasTurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmasTurmaId",
                table: "Alunos",
                column: "TurmasTurmaId",
                principalTable: "Turmas",
                principalColumn: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Escolas_Escola",
                table: "Turmas",
                column: "Escola",
                principalTable: "Escolas",
                principalColumn: "EscolaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
