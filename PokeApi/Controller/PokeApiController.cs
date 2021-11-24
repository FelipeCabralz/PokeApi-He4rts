using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeApi.Domain;
using PokeApi.Domain.ViewModels;
using PokeApi.Repository;
using System;
using System.Threading.Tasks;

namespace PokeApi.WebAPI.Controller
{
    [Route("v1")]
    [ApiController]
    public class PokeApiController : ControllerBase
    {
        //private readonly IPokemonRepository _repo;

        //public PokeApiController(IPokemonRepository repo)
        //{
        //    _repo = repo;
        //}

        [HttpGet, Route("pokemons")]
        public async Task<IActionResult> GetAsync(
            [FromServices] PokeApiContext context)
        {
            var pokemons = await context
                .Pokemons
                .AsNoTracking()
                .ToListAsync();
            return Ok(pokemons);

            //try
            //{
            //    var pokemons = await _repo.GetAllPokemonsAsync();

            //    return Ok(pokemons);
            //}
            //catch (System.Exception ex)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            //}
        }

        [HttpGet("pokemons/{pokemonId}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] PokeApiContext context,
            [FromRoute] Guid pokemonId)
        {
            var pokemon = await context
                .Pokemons
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PokemonId == pokemonId);

            return pokemon == null
                ? NotFound()
                : Ok(pokemon);

            //try
            //{
            //    var pokemons = await _repo.GetPokemonsAsyncById(pokemonId);
            //    if (pokemonId == Guid.Empty) return NotFound();

            //    return Ok(pokemons);
            //}
            //catch (System.Exception ex)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            //}
        }

        [HttpPost, Route("pokemon")]
        public async Task<IActionResult> PostAsync(
            [FromServices] PokeApiContext context,
            [FromBody] CreatePokemonViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemon = new Pokemon
            {

                Nome = model.Nome,
                Imagem_Url = model.Imagem_Url,
                Atributos = model.Atributos,
            };

            try
            {
                await context.Pokemons.AddAsync(pokemon);
                await context.SaveChangesAsync();
                return Created($"v1/pokemon/{pokemon.PokemonId}", pokemon);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            //try 
            //{
            //    _repo.Add(pokemon);

            //    if (await _repo.SaveChangesAsync())
            //    {
            //        return Ok();
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError,
            //        $"Banco de Dados falhou {ex.Message}");
            //}

            //return BadRequest();
        }

        [HttpPut("pokemons/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] PokeApiContext context,
            [FromBody] CreatePokemonViewModel model,
            [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var pokemon = await context.Pokemons.FirstOrDefaultAsync(x => x.PokemonId == id);

            if (pokemon == null)
                return NotFound();

            try
            {
                pokemon.Nome = model.Nome;
                pokemon.Imagem_Url = model.Imagem_Url;
                pokemon.Atributos = model.Atributos;

                context.Pokemons.Update(pokemon);
                await context.SaveChangesAsync();
                return Ok(pokemon);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            //try
            //{
            //    if (pokemon == null) return NotFound();

            //    _repo.Edit(pokemon);

            //    if (await _repo.SaveChangesAsync())
            //    {
            //        return Ok(pokemon);
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            //}
            //return BadRequest();
        }

        [HttpDelete("pokemons/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] PokeApiContext context,
            [FromRoute] Guid id)
        {
            var pokemon = await context.Pokemons.FirstOrDefaultAsync(x => x.PokemonId == id);

            try
            {
                context.Pokemons.Remove(pokemon);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            //try
            //{
            //    var pokemon = await _repo.GetPokemonsAsyncByName(pokemonId);
            //    if (pokemon == null) return NotFound();// ou também pokemonId == Guid.Empty

            //    _repo.Delete(pokemon);

            //    if (await _repo.SaveChangesAsync())
            //    {
            //        return Ok();
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou {ex.Message}");
            //}

            //return BadRequest();
        }

    }
}
