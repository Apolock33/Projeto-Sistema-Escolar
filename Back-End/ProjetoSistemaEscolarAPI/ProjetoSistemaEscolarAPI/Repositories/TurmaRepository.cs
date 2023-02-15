using ProjetoSistemaEscolarAPI.Models;
using ProjetoSistemaEscolarAPI.Models.Context;
using ProjetoSistemaEscolarAPI.Repository.Interfaces;

namespace ProjetoSistemaEscolarAPI.Repository
{
    public class TurmaRepository : Repository<Turmas>, ITurmaRepository
    {
        public TurmaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
