using ProjetoSistemaEscolarAPI.Models;
using ProjetoSistemaEscolarAPI.Models.Context;
using ProjetoSistemaEscolarAPI.Repository.Interfaces;

namespace ProjetoSistemaEscolarAPI.Repository
{
    public class MateriaRepository : Repository<Materias>, IMateriaRepository
    {
        public MateriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
