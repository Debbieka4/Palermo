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



        void CastVotes() 
        {
            foreach (Player player in game.Players) 
            {
                Console.WriteLine("Who will be casting the vote?");

                var voterName = Console.ReadLine();

                var voter = player.Where(p => p.Name == voterName);


                Console.WriteLine("Who will you be voting?");

                var targetName = Console.ReadLine();

                var target = player.Where(p => p.Name == targetName);

                Vote vote = new Vote();

                vote.CastVote(voter, target, game.Players);
            }
        }

    }



   


}



