using Microsoft.EntityFrameworkCore;
using ProjetoSistemaEscolarAPI.Models.Context;
using ProjetoSistemaEscolarAPI.Repository.Interfaces;
using System.Linq.Expressions;

namespace ProjetoSistemaEscolarAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext _context;

        public Repository(AppDbContext context) 
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            _context.Remove<T>(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable<T>();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Post(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Put(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}
