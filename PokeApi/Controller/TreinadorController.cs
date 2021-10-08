using Microsoft.AspNetCore.Mvc;
using PokeApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApi.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinadorController : ControllerBase
    {
        private readonly IRepository _repo;

        public TreinadorController(IRepository repo)
        {
            _repo = repo;
        }
    }
}
