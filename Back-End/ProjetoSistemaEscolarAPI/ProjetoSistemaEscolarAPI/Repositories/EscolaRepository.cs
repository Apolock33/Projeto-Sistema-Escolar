using ProjetoSistemaEscolarAPI.Models;
using ProjetoSistemaEscolarAPI.Models.Context;
using ProjetoSistemaEscolarAPI.Repository.Interfaces;

namespace ProjetoSistemaEscolarAPI.Repository
{
    public class EscolaRepository : Repository<Escolas>, IEscolaRepository
    {
        public EscolaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
