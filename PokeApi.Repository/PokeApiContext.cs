using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokeApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Repository
{
    public class PokeApiContext : DbContext
    {
        public PokeApiContext(DbContextOptions<PokeApiContext> options) : base(options) { }

        public DbSet<Treinador> Treinadores { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TreinadorPokemon>().HasKey(sc => new { sc.TreinadorId, sc.PokemonId });
        }
    }
}
