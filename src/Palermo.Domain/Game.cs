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
        public GamePhazes CurrentPhaze { get; set; }
        public int RoundCount { get; private set; }

        public Utils Utils = new Utils();



        public Game()
        {
            this.Players = new List<Player>();
            this.RoundCount = 1;

        }

        /// <summary>
        /// Sets up the game by assigning roles randomly.
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <param name="playerNames"></param>
        public void InitializeGame(int numberOfPlayers, List<string> playerNames)
        {

            if (numberOfPlayers > 3 && playerNames.Any() && playerNames.Count > 3)
            {
                var playerIds = GeneratePlayerId(numberOfPlayers);

            Utils.ShuffleList(playerNames);

            

                for (int i = 0; i == numberOfPlayers; i++)
                {
                    for (int j = i; j < 2; j++)
                    {
                        Mafia mafia = new Mafia(playerNames[j], playerIds[j]);
                        i++;
                    }
                    for (int v = i; v < i + 1; v++)
                    {
                        Detective detective = new Detective(playerNames[v], playerIds[v]);
                        i++;
                    }

                    Citizen citizen = new Citizen(playerNames[i], playerIds[i]);
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
        /// <param name="players"></param>
        public List<int> GeneratePlayerId(int numberOfPlayers) 
        {

            var generateIds = Enumerable.Range(0, numberOfPlayers);
            var finalIds = generateIds.Select(id => id).ToList();
            return finalIds;

        }


        /// <summary>
        /// Starts the main game loop, alternating between Day and Night phases.
        /// </summary>
        public void Start() 
        {
          
          
        }


        /// <summary>
        /// Handles all actions for the Night phase.
        /// Removes the target player - Mafia's selection - from the Players list.
        /// </summary>
        /// <param name="targetPlayerId"></param>
        public void ExecuteNightPhase(int targetPlayerId) 
        {
            CurrentPhaze = GamePhaze.Night;

         var eliminatedPlayer = string.Empty;
         foreach (var player in Players) 
            {
                if (player.Id.Equals(targetPlayerId)) 
                {
                 Players.Remove(player);
                }
            }
        }


        /// <summary>
        /// Handles voting and discussions for the Day phase.
        /// It takes as a parameter a Dictionary which includes the id of the voter
        /// and the player that they are voting.
        /// </summary>
        public string ExecuteDayPhase(Dictionary<int, int> votes) 
        {
            CurrentPhaze = GamePhaze.Day;

            Vote vote = new Vote(votes);
            var eliminatedPlayerName = vote.VotingProcess(Players);
            return eliminatedPlayerName;
            
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
        public Dictionary<string, string> DisplayResults() 
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
