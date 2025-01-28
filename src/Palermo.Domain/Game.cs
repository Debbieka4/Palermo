﻿using Palermo.Domain.Core.Logic.Enum;
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
    internal class Game
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
        /// </summary>
        public void ExecuteNightPhase() 
        {
        
        }


        /// <summary>
        /// Handles voting and discussions for the Day phase.
        /// It takes as a parameter a Dictionary which includes the id of the voter
        /// and the player that they are voting.
        /// </summary>
        public void ExecuteDayPhase(Dictionary<int, int> votes) 
        {
            Vote vote = new Vote(votes);
            vote.VotingProcess(Players);
            
        }


        /// <summary>
        /// Determines if the game has ended and which side has won.
        /// </summary>
        /// <returns></returns>
        public bool CheckVictoryConditions() 
        {
            return false;
        }

        /// <summary>
        /// Shows the final roles and outcome of the game.
        /// </summary>
        public void DisplayResults() 
        {
        
        }
    }
}
