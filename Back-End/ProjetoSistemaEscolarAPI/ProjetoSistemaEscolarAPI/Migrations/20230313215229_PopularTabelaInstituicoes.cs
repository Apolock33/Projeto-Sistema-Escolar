using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSistemaEscolarAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelaInstituicoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Instituicao(IdInstituicao, CodigoInstituicao, QtdAlunos, QtdTurmas, QtdCursos) VALUES(NEWID(), 001, 1, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Instituicao(IdInstituicao, CodigoInstituicao, QtdAlunos, QtdTurmas, QtdCursos) VALUES(NEWID(), 002, 2, 2, 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Instituicao");
        }
    }
}
