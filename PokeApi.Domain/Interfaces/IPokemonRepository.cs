using System;
using System.Threading.Tasks;

namespace PokeApi.Domain.Interfaces
{
    public interface IPokemonRepository : IRepository<Pokemon>
    {
        Task<Pokemon[]> GetAllPokemonsAsync();
        Task<Pokemon> GetPokemonsAsyncById(Guid pokemonId);
        Task<Pokemon> GetPokemonsAsyncByName(Guid pokemonId);
    }
}
