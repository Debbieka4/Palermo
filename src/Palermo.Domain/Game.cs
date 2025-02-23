using Palermo.Domain.Core.Logic.Enum;
using Palermo.Domain.Core.Logic.Interfaces;
using Palermo.Domain.Core.Logic.Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Palermo.Domain.Core.Logic
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public GamePhaze CurrentPhaze { get; set; }
        public int RoundCount { get; }
        public int PlayersCount { get; }

        public Utils Utils = new Utils();



        public Game(int roundCount, int playersCount)
        {
            Players = new List<Player>();
            RoundCount = roundCount;
            PlayersCount = playersCount;

        }

        /// <summary>
        /// Sets up the game by assigning roles randomly.
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <param name="playerNames"></param>
        public void InitializeGame(List<string> playerNames)
        {

            if (PlayersCount > 3 && playerNames.Any() && playerNames.Count > 3)
            {
                var playerIds = GeneratePlayerId(PlayersCount);

            Utils.ShuffleList(playerNames);

            

                for (int i = 0; i < PlayersCount + 1; i++)
                {
                    for (int j = i; j < 2; j++)
                    {
                        Mafia mafia = new Mafia(playerNames[j], playerIds[j], RoleType.Mafia);
                        Players.Add(mafia);
                        i++;
                    }
                    for (int v = i; v < i + 1; v++)
                    {
                        Detective detective = new Detective(playerNames[v], playerIds[v], RoleType.Detective);
                        Players.Add(detective);
                        i++;
                    }

                    Citizen citizen = new Citizen(playerNames[i], playerIds[i], RoleType.Citizen);
                    Players.Add(citizen);
                }
            }

            else 
            {
                throw new Exception("Number of players must be over 3.");
            }
           
            
          


        }


        /// <summary>
        /// Generates a unique ID for each player.
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <returns></returns>
        public List<int> GeneratePlayerId(int numberOfPlayers) 
        {

            var generateIds = Enumerable.Range(0, PlayersCount);
            var finalIds = generateIds.Select(id => id).ToList();
            return finalIds;

        }


        /// <summary>
        /// Starts the main game loop, alternating between Day and Night phases.
        /// </summary>
        public void Start() 
        {
            for (var i = 0; i < RoundCount + 1; i++) 
            {
                ExecuteDayPhase();
                ExecuteNightPhase();
            }
          
        }


        /// <summary>
        /// 
        /// </summary>
        public void ExecuteNightPhase() 
        {
            CurrentPhaze = GamePhaze.Night;

       
        }


        /// <summary>
        /// 
        /// </summary>
        public void ExecuteDayPhase() 
        {
            CurrentPhaze = GamePhaze.Day;
            VotingService votingService = new VotingService(Players);


           
            
            
        }

    


        /// <summary>
        /// Determines if the game has ended.
        /// </summary>
        /// <returns></returns>
        public bool CheckVictoryConditions() 
        {
            
            if (!Players.Select(p => p.Role).Equals(RoleType.Detective))
            {
                /// the game has ended because the Detective has died. 
                return true;
            }

            if (!Players.Select(p => p.Role).Equals(RoleType.Mafia))
            {
                /// the game has ended because the Mafia have died. 
                return  true;
            }
            else 
            {
                /// both the Mafia and the Detective are alive.
                return false;
            }

        }


        /// <summary>
        /// Determines which side has won.
        /// </summary>
        /// <returns></returns>
        public bool HasGoodWon() 
        {

            bool goodHasWon = false;

            if (CheckVictoryConditions() && Players.Select(p => p.Role).Equals(RoleType.Detective))
            {
                goodHasWon = true;
            }

            else
            {
                goodHasWon = false;
            }

            return goodHasWon;
        }

        /// <summary>
        /// Shows the final roles and outcome of the game.
        /// </summary>
        public Dictionary<string, string> RevealRoles() 
        {
            Dictionary<string, string> playerWithRoles = new Dictionary<string, string>();

            foreach (var player in Players) 
            {

             playerWithRoles.Add(player.Name, player.Role.ToString());

            }

            return playerWithRoles;
        }
    }
}
