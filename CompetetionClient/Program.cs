using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace CompetetionClient
{
#pragma warning disable
    internal class Program
    {
        protected Program()
        {

        }
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var playerClient = new Players.PlayersClient(channel);



            #region Create          
/*
            var newPlayer = new PlayerDto()
            {
                FirstName = "Kamron",
                LastName = "Samadov",
                Age = 25,
                SportType = "Restling"
            };

            var addedPlayer = await playerClient.CreateAsync(newPlayer);

            Console.WriteLine($"FirstName:{addedPlayer.FirstName}\nLastName: {addedPlayer.LastName}\nAge: {addedPlayer.Age}\nSport type: {addedPlayer.SportType}");
*/
            #endregion


            #region Update
            /*
            var updatingPlayer = new PlayerModelForUpdate()
            {
                PlayerID = 6,
                PlayerDto = new PlayerDto
                {
                    FirstName = "Zafarbek",
                    LastName = "Bo'riyev",
                    Age = 26,
                    SportType = "Tennis"
                }
            };
            var updatedPlayer = await playerClient.UpdateAsync(updatingPlayer);

            Console.WriteLine($"FirstName:{updatedPlayer.FirstName}\nLastName: {updatedPlayer.LastName}\nAge: {updatedPlayer.Age}\nSport type: {updatedPlayer.SportType}");
            */
            #endregion


            #region Delete
            /*
                        DeleteId deletingPlayerId = new DeleteId { PlayerID = 7 };

                        var isDeleted = await playerClient.DeleteAsync(deletingPlayerId);
                        if (isDeleted.IsDeleted_)
                        {
                            Console.WriteLine("Player successfully Deleted");
                        }
                        else
                            Console.WriteLine("Delete operation was not successfull");
            */
            #endregion



            #region GetByID
            /*
                        var clientId = new PlayerRequestById { PlayerID = 6  };


                        var client = await playerClient.GetByIdAsync(clientId);

                        Console.WriteLine($"FirstName:{client.FirstName}\nLastName: {client.LastName}\nAge: {client.Age}\nSport type: {client.SportType}");
            */
            #endregion


            #region GetAll
/*
            using (var call = playerClient.GetAll(new EmptyRequest()))
            {

                while (await call.ResponseStream.MoveNext())
                {
                    var currentPlayer = call.ResponseStream.Current;
                    Console.WriteLine($"FirstName:{currentPlayer.FirstName}\nLastName: {currentPlayer.LastName}\nAge: {currentPlayer.Age}\nSport type: {currentPlayer.SportType}");
                }
            }
*/
            #endregion

        }
    }
}
