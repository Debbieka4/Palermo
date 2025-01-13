using Palermo.Domain.Core.Logic.Enum;
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
        public int RoundCount { get;  private set; }

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
            List<Roles> rolesList = new List <Roles>();

            Utils.ShuffleList(rolesList);

            

            for (int i; i < numberOfPlayers; i++) 
            {
           

                
            }
          


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
        /// </summary>
        public void ExecuteDayPhase() 
        {
        
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
