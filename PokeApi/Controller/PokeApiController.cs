using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Domain;
using PokeApi.Domain.Interfaces;
using PokeApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                if (pokemonId == Guid.Empty) return NotFound();

                return Ok(pokemons);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            }
        }

        [HttpPost, Route("criar_pokemon")]
        public async Task<IActionResult> Post([FromBody] Pokemon pokemon)
        {
            try 
            {
                _repo.Add(pokemon);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco de Dados falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{pokemonId}")]
        public async Task<IActionResult> Put([FromBody] Pokemon pokemon) 
        {
            try
            {
                if (pokemon == null) return NotFound();

                _repo.Edit(pokemon);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            }
            return BadRequest();
        } 

        [HttpDelete("{pokemonId}"), Route("{atualizar}")]
        public async Task<IActionResult> Delete(Guid pokemonId)
        {
            try
            {
                var pokemon = await _repo.GetPokemonsAsyncByName(pokemonId);
                if (pokemon == null) return NotFound();// ou também pokemonId == Guid.Empty

                _repo.Delete(pokemon);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            }

            return BadRequest();
        }

    }
}
