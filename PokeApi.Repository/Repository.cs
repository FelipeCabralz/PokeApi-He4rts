using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PokeApiContext _context;
        public Repository(PokeApiContext context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delelete(int id)
        {
            var q = GetById(id);
            _context.Set<T>().Remove(q);
        }

        public void Edit(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().Select(a => a).ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Savechange()
        {
            return _context.SaveChanges();
        }
    }
}
