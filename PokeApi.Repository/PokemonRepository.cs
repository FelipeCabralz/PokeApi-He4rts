using Microsoft.EntityFrameworkCore;
using PokeApi.Domain;
using PokeApi.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApi.Repository
{
    public class PokemonRepository : RepositoryBase<Pokemon>, IPokemonRepository
    {
        public PokemonRepository(PokeApiContext context) : base(context)
        {
        }

        public async Task<Pokemon[]> GetAllPokemonsAsync()
            => await DbSet.ToArrayAsync();

        public async Task<Pokemon> GetPokemonsAsyncById(Guid pokemonId)
            => await DbSet
                .AsNoTracking()
                .OrderBy(c => c.PokemonId)
                .Where(c => c.PokemonId == pokemonId).AsSplitQuery()
                .FirstOrDefaultAsync();
    }
}
