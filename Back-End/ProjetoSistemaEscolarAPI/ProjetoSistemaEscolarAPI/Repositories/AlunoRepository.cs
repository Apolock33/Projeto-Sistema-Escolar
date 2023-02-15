using ProjetoSistemaEscolarAPI.Models;
using ProjetoSistemaEscolarAPI.Models.Context;
using ProjetoSistemaEscolarAPI.Repository.Interfaces;

namespace ProjetoSistemaEscolarAPI.Repository
{
    public class AlunoRepository : Repository<Alunos>, IAlunoRepository
    {
        public AlunoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
