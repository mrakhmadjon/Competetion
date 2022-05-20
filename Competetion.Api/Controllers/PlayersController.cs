using Competetion.Api.Dtos;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


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
        public async ValueTask<IEnumerable<Player>> GetAllAsync()
        {
            return await playerRepository.GetAllAsync();
        }

       
        [HttpGet("{id}")]
        public async ValueTask<Player> Get(int id)
        {
            return await playerRepository.GetByIdAsync(id);
        }

       
        [HttpPost]
        public async ValueTask<Player> Post(Player player)
        {
            var postedPlayer =  await playerRepository.AddAsync(player);
            await unitOfWork.Commit();
            return postedPlayer;
        }

        
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> Put(int id, PlayerDto player)
        {
            var playerAsked = await playerRepository.GetByIdAsync(id);
            if(playerAsked != null)
            {
                playerAsked.FirstName = player.FirstName;
                playerAsked.LastName = player.LastName;
                playerAsked.Age = player.Age;
                playerAsked.SportType = player.SportType;
                var updatedPlayer = await playerRepository.UpdateAsync(playerAsked);
                await unitOfWork.Commit();
                return Ok(updatedPlayer);
            }
            return NotFound();
        }

       
        [HttpDelete("{id}")]
        public async ValueTask<bool> Delete(int id)
        {
            var isDeleted =  await playerRepository.DeleteAsync(id);
            await unitOfWork.Commit();
            return isDeleted;
        }
    }
}
