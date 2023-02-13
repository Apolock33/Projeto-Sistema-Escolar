using Microsoft.EntityFrameworkCore;

namespace ProjetoSistemaEscolarAPI.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Turmas> Turmas { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Escolas> Escolas { get; set; }
        public DbSet<TurmaMateria> TurmaMateria { get;set; }
    }
}
