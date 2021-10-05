using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Domain
{
    public class Treinador
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Regioes { get; set; }
        public int Idade { get; set; }
    }
}
