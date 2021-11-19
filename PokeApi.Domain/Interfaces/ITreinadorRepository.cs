using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Domain.Interfaces
{
    public interface ITreinadorRepository : IRepository<Treinador>
    {
        Task<Treinador[]> GetAllTreinadoresAsync();
    }
}
