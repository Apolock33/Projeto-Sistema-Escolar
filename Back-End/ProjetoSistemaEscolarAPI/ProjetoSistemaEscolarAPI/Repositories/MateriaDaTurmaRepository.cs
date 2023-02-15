using ProjetoSistemaEscolarAPI.Models;
using ProjetoSistemaEscolarAPI.Models.Context;
using ProjetoSistemaEscolarAPI.Repository.Interfaces;

namespace ProjetoSistemaEscolarAPI.Repository
{
    public class MateriaDaTurmaRepository : Repository<MateriasDasTurmas>, IMateriaDaTurmaRepository
    {
        public MateriaDaTurmaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
