using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Domain.Interfaces;
using PokeApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApi.WebAPI.Controller
{
    [Route("pokemons")]
    [ApiController]
    public class PokeApiController : ControllerBase
    {
        private readonly IPokemonRepository _repo;

        public PokeApiController(IPokemonRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pokemons = await _repo.GetAllPokemonsAsync();

                return Ok(pokemons);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            }
        }

        [HttpGet("{pokemonId}")]
        public async Task<IActionResult> Get(Guid pokemonId)
        {
            try
            {
                var pokemons = await _repo.GetPokemonsAsyncById(pokemonId);

                return Ok(pokemons);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            }
        }

    }
}
