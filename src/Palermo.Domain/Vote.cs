using Palermo.Domain.Core.Logic.Enum;
using Palermo.Domain.Core.Logic.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public int PlayerTotalVotes = 0;

        /// <summary>
        /// Records a vote from one player to another.
        /// </summary>
        /// <param name="voterId"></param>
        /// <param name="targetId"></param>
        public void CastVote(int voterId, int targetId, List<Player> players)
        {

            foreach (Player player in players)
            {
                if (!player.HasVoted)
                {
                    if (player.Id == voterId)
                    {
                        player.HasVoted = true;
                    }
                }
                else 
                {
                    throw new Exception("This player has already voted, cannot vote twice.");
                }
            }

            Votes.Add(targetId, PlayerTotalVotes + 1);
            PlayerTotalVotes++;


           
            
              
            

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
