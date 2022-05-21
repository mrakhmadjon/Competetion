using DataAccess.Interfaces;
using Grpc.Core;
using System.Threading.Tasks;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace CompetetionServer.Services
{
    public class PlayersService : Players.PlayersBase
    {
        private  IUnitOfWork unitOfWork { get; }
        public PlayersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public override async Task<PlayerModel> Create(PlayerDto request, ServerCallContext context)
        {
            Player newPlayer = new Player()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                SportType = request.SportType
            };
            var addedPlayer = await unitOfWork.Players.AddAsync(newPlayer);
            await unitOfWork.Commit();

            return new PlayerModel()
            {
                PlayerID = addedPlayer.Id,
                FirstName = addedPlayer.FirstName,
                LastName = addedPlayer.LastName,
                SportType = addedPlayer.SportType,
                Age = addedPlayer.Age
            };
         }

        public override async Task GetAll(EmptyRequest request, IServerStreamWriter<PlayerModel> responseStream, ServerCallContext context)
        {
            var allPlayers = await unitOfWork.Players.GetAllAsync();
            

            foreach (var player in allPlayers)
            {
                PlayerModel playerModel = new PlayerModel()
                {
                    PlayerID = player.Id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Age = player.Age,
                    SportType = player.SportType
                };
                await responseStream.WriteAsync(playerModel);
            }
        }
        
        public override async Task<PlayerModel> GetById(PlayerRequestById request, ServerCallContext context)
        {
            var player = await unitOfWork.Players.GetByIdAsync(request.PlayerID);

            if(player != null)
            {
                PlayerModel playerModel = new PlayerModel()
                {
                    PlayerID = player.Id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Age = player.Age,
                    SportType = player.SportType

                };

                return playerModel;
            }

           throw new RpcException(new Status(StatusCode.NotFound, "No Player was found"));

        }
        
        public override async Task<PlayerModel> Update(PlayerModelForUpdate request, ServerCallContext context)
        {
            
            var newPlayer = await unitOfWork.Players.GetByIdAsync(request.PlayerID);
            if(newPlayer != null)
            {
                newPlayer.FirstName = request.PlayerDto.FirstName;
                newPlayer.LastName = request.PlayerDto.LastName;
                newPlayer.SportType = request.PlayerDto.SportType;
                newPlayer.Age = request.PlayerDto.Age;
                await unitOfWork.Players.UpdateAsync(newPlayer);
                await unitOfWork.Commit();
                return new PlayerModel
                {
                    PlayerID = newPlayer.Id,
                    FirstName = newPlayer.FirstName,
                    LastName = newPlayer.LastName,
                    SportType = newPlayer.SportType,
                    Age = newPlayer.Age
                    
                };
            }

            return null;
        }


        public override async Task<IsDeleted> Delete(DeleteId request, ServerCallContext context)
        {
            var player = await unitOfWork.Players.GetByIdAsync(request.PlayerID);
            if(player != null)
            {
                await unitOfWork.Players.DeleteAsync(player.Id);
                await unitOfWork.Commit();
                return new IsDeleted
                {
                    IsDeleted_ = true,
                };
            }
            return new IsDeleted() { IsDeleted_ = false};
        }

    }
}
