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
        public string GetRandomPlayer(List<string> players) 
        {
            Random random = new Random();
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
            Random random = new Random();

            //Sets i to the list's max index and it runs till it reaches Zero.
            for (int i = list.Count - 1; i > 0; i--) 
            {
             int randomIndex = random.Next(0, i + 1);

             //The list value on the index i is stored in temporaryValue to ensure
             //it is safe. Then In the index of i the value of randomIndex is saved.
             //Lastly in the randomIndex the value of index i is store, attaining the shuffle
             //of list items as the values of i and randomIndex have been swapped.
             T temporaryValue = list[i];
             list[i] = list[randomIndex];
             list[randomIndex] = temporaryValue;
            }
        }
    }
}
