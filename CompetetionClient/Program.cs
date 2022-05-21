using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace CompetetionClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var playerClient = new Players.PlayersClient(channel);

            #region Create          
            /*
                        var newPlayer = new PlayerDto()
                        {
                            FirstName = "Zafar",
                            LastName = "Bo'riyev",
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
            var clientId = new PlayerRequestById { PlayerID = 1  };


            var client = await playerClient.GetByIdAsync(clientId);
            
            Console.WriteLine($"FirstName:{client.FirstName}\nLastName: {client.LastName}\nAge: {client.Age}\nSport type: {client.SportType}");

            #endregion


        }
    }
}
