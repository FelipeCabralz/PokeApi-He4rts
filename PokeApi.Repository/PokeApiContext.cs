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
    public class PokeApiContext : IdentityDbContext
    {
        public PokeApiContext(DbContextOptions<PokeApiContext> options) : base(options) { }

        public DbSet<Treinadores> Treinadores { get; set; }
    }
}
