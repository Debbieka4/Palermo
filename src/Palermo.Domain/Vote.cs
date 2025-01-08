using Palermo.Domain.Core.Logic.Enum;
using Palermo.Domain.Core.Logic.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Domain.Core.Logic
{
    internal class Vote
    {
        /// <summary>
        /// Maps player IDs to the number of votes received.
        /// </summary>
        public Dictionary<int, int> Votes { get; set; }

        /// <summary>
        /// Records a vote from one player to another.
        /// </summary>
        /// <param name="voterId"></param>
        /// <param name="targetId"></param>
        public void CastVote(int voterId, int targetId)
        {

        }

        /// <summary>
        /// Determines the player with the most votes.
        /// </summary>
        /// <returns></returns>
        public int GetEliminatedPlayerId() 
        {
            return 0;
        } 
    }
}
