using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Domain
{
    public class Pokemon
    {
        public Guid PokemonId { get; set; }
        public string Nome { get; set; }
        public string Imagem_Url { get; set; }
        public string Atributos { get; set; }
    }
}
