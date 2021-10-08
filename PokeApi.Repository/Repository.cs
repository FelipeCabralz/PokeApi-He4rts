using Microsoft.EntityFrameworkCore;
using PokeApi.Domain;
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

        public void Delete(int id)
        {
            var pokemon = GetById(id);
            _context.Set<T>().Remove(pokemon);
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

        public async Task<bool> SavechangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //TREINADOR

        public async Task<Treinador[]> GetAllTreinadoresAsync()
        {
            IQueryable<Treinador> query = _context.Treinadores;

            return await query.ToArrayAsync();
        }

        public async Task<Pokemon[]> GetAllPokemonsAsync()
        {
            IQueryable<Pokemon> query = _context.Pokemons;

            return await query.ToArrayAsync();
        }
    }
}
