using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Competetion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPlayerRepository playerRepository;

        public PlayersController(IUnitOfWork unitOfWork, IPlayerRepository playerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.playerRepository = playerRepository;
        }


        [HttpGet]
        public async ValueTask<IEnumerable<Player>> GetAsync()
        {
            return await playerRepository.GetAllAsync();
        }

        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public async ValueTask<Player> Get(int id)
        {
            return await playerRepository.GetByIdAsync(id);
        }

        // POST api/<PlayersController>
        [HttpPost]
        public async ValueTask<Player> Post(Player player)
        {
            return await playerRepository.AddAsync(player);
        }

        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public void Put(Player player)
        {

        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
