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
    public class Utils
    {

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
        public List<T> ShuffleList<T>(List<T> list) 
        {
            Random random = new Random();

            List<T> shuffledList = new List<T>();

            List<T> copyList = list;

            for (int i = 0; i < list.Count - 1; i++) 
            {
                var randomItem = list[random.Next(copyList.Count)];

                shuffledList.Add(randomItem);

                copyList.Remove(randomItem);
            }

            return shuffledList;
        }
    }
}
