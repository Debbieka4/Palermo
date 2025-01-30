using System.Security.Cryptography.X509Certificates;
using Palermo.Domain.Core.Logic;
using Palermo.Domain.Core.Logic.Players;

public class Program
{


    


    static void Main()
    {

        Game game = new Game();

        List<string> playerNames = new List<string>();

        int numberOfPlayers = 0;

        GetPlayerNames();

        game.InitializeGame(numberOfPlayers, playerNames);

        foreach (Player player in game.Players)
        {

            Console.WriteLine($" Player " + player.Name + " has the role of " + player.Role);

        }


       void GetPlayerNames()
        {

            Console.WriteLine("How many players will be playing? Number of players must be over 3");
            var totalPlayers = Console.ReadLine();

            if (totalPlayers != null)
            {

                numberOfPlayers = int.Parse(totalPlayers);

                if (numberOfPlayers > 3)
                {

                    Console.WriteLine("Now insert all player names.");

                    for (int i = 0; i < numberOfPlayers; i++)
                    {

                        var playerName = Console.ReadLine();
                        playerNames.Add(playerName);

                    }

                }

                else
                {
                    Console.WriteLine("Number of players must be over 3.");
                    return;
                }
            }

            else
            {
                Console.WriteLine("Insert valid number.");
                return;
            }
        }


    }



   


}



