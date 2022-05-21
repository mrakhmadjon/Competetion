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

        public PlayersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async ValueTask<IEnumerable<Player>> GetAllAsync()
        {
            return await unitOfWork.Players.GetAllAsync();
            
        }

       
        [HttpGet("{id}")]
        public async ValueTask<Player> Get(int id)
        {
            return await unitOfWork.Players.GetByIdAsync(id);
        }

       
        [HttpPost]
        public async ValueTask<Player> Post(PlayerDto player)
        {
            Player player1 = new Player
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Age = player.Age,
                SportType = player.SportType
            };
            var postedPlayer =  await unitOfWork.Players.AddAsync(player1);
            await unitOfWork.Commit();
            return postedPlayer;
        }

        
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> Put(int id, PlayerDto player)
        {
            var playerAsked = await unitOfWork.Players.GetByIdAsync(id);
            if(playerAsked != null)
            {
                playerAsked.FirstName = player.FirstName;
                playerAsked.LastName = player.LastName;
                playerAsked.Age = player.Age;
                playerAsked.SportType = player.SportType;
                var updatedPlayer = await unitOfWork.Players.UpdateAsync(playerAsked);
                await unitOfWork.Commit();
                return Ok(updatedPlayer);
            }
            return NotFound();
        }

       
        [HttpDelete("{id}")]
        public async ValueTask<bool> Delete(int id)
        {
            var isDeleted =  await unitOfWork.Players.DeleteAsync(id);
            await unitOfWork.Commit();
            return isDeleted;
        }
    }
}
