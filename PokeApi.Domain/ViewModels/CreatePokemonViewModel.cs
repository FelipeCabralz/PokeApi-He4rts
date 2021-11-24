using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Domain.ViewModels
{
    public class CreatePokemonViewModel
    {
        [Required]
        public string Nome { get; set; }
        public string Imagem_Url { get; set; }
        public string Atributos { get; set; }
    }
}
