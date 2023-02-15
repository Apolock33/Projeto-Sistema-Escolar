using System.Linq.Expressions;

namespace ProjetoSistemaEscolarAPI.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Post(T entity);
        IEnumerable<T> GetAll();
        T GetById(Expression<Func<T, bool>> predicate);
        void Put(T entity);
        void Delete(T entity);
    }
}
