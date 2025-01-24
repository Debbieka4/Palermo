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

        public Dictionary<Player, int> Player { get; set; }

        public int PlayerTotalVotes = 0;

        /// <summary>
        /// Records a vote from one player to another.
        /// </summary>
        /// <param name="voterId"></param>
        /// <param name="targetId"></param>
        public void CastVote(int voterId, int targetId, List<Player> players)
        {
            var targetPlayer = players.SkipWhile(p => p.Id != targetId).TakeWhile(p => p.Id == targetId);

            

            foreach (Player player in players)
            {
                if (player.Id == voterId)
                {

                    if (!player.HasVoted)
                    {            
                        player.HasVoted = true;
                        Votes.Add(voterId, targetId);
                        Player.Add((Player)targetPlayer, PlayerTotalVotes + 1);
                        PlayerTotalVotes++;
                    }
                    else
                    {
                        throw new Exception("This player has already voted, cannot vote twice.");
                    }
                }
                else
                {
                    throw new Exception("Voter Id doesn't exist.");
                }
                
            }

            


           
            
              
            

        }

        /// <summary>
        /// Determines the player with the most votes.
        /// </summary>
        /// <returns></returns>
        public Player GetEliminatedPlayerId() 
        {
            var playerWithMaxVote = Player.Max();
            return playerWithMaxVote.Key; 
        } 
    }
}
