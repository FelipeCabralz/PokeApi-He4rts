using Microsoft.EntityFrameworkCore;
using PokeApi.Domain;
using PokeApi.Domain.Interfaces;
using System.Threading.Tasks;

namespace PokeApi.Repository
{
    public class TreinadorRepository : RepositoryBase<Treinador>, ITreinadorRepository
    {
        public TreinadorRepository(PokeApiContext context) : base(context)
        {
        }

        public async Task<Treinador[]> GetAllTreinadoresAsync()
            => await DbSet.ToArrayAsync();
    }
}
