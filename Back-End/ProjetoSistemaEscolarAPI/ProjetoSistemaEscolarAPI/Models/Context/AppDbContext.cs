using Microsoft.EntityFrameworkCore;

namespace ProjetoSistemaEscolarAPI.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<MateriaXTurma> MateriaXTurma { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
    }
}
