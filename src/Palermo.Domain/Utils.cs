using Palermo.Domain.Core.Logic.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Domain.Core.Logic
{
    /// <summary>
    /// Helper Class.
    /// </summary>
    internal class Utils
    {

        public Random random = new Random();
        /// <summary>
        /// Selects a random player by name from the list.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public Player GetRandomPlayer(List<Player> players) 
        {

            var randomPlayer = players[random.Next(players.Count)];
            return randomPlayer;
        }

        /// <summary>
        /// Shuffles a list(useful for assigningroles).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void ShuffleList<T>(List<T> list) 
        { 
        
        }
    }
}
