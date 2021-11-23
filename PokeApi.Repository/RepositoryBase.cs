using Microsoft.EntityFrameworkCore;
using PokeApi.Domain;
using PokeApi.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApi.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly PokeApiContext _context;
        public readonly DbSet<TEntity> DbSet;

        public RepositoryBase(PokeApiContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public List<TEntity> GetAll()
            => DbSet.Select(a => a).ToList();

        public TEntity GetById(object id)
            => DbSet.Find(id);

        public async Task<bool> SaveChangesAsync()
            => (await _context.SaveChangesAsync()) > 0;
    }
}
