using Palermo.Domain.Core.Logic.Enum;
using Palermo.Domain.Core.Logic.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Domain.Core.Logic
{
    public class Vote
    {        
        

       /// <summary>
       /// Maps the voter's id to the id of the player they are voting.
       /// Key: voter id, Value: target player id.
       /// </summary>
        public Dictionary<Player, Player> HaveVoted { get; set; }

        

        /// <summary>
        /// Casts another player's vote towards the player of their choosing.
        /// </summary>
        /// <param name="voter"></param>
        /// <param name="target"></param>
        /// <param name="players"></param>
        /// <exception cref="Exception"></exception>

        public void CastVote(Player voter, Player target, List<Player> players) 
        {
                List<Player> alivePlayers = players.Where(p => p.IsAlive == true).ToList();

            if (alivePlayers.Contains(voter) && alivePlayers.Contains(target))
            {
                if (!HaveVoted.ContainsKey(voter))
                {
                    if (!voter.IsVotingThemselves(voter))
                    {
                        target.AddVote();
                        HaveVoted.Add(voter, target);
                    }
                    else
                    {
                        throw new Exception("Player cannot vote themselves.");
                    }
                }
                else
                {
                    throw new Exception("Player " + voter.Name + " has already voted, cannot vote twice.");
                }
            }
            else
            {
                throw new Exception("Players " + voter.Name + " and " + target.Name + " are not alive and are unable to vote.");
            }
        }




        /// <summary>
        /// Resets the number of votes on each player and clears the documents of who voted for whom in the previous round. 
        /// </summary>
        /// <param name="players"></param>
        public void ResetVotingProcess(List<Player> players) 
        {
            HaveVoted.Clear();
            foreach (Player player in players) 
            {
             player.ResetVotes();
            }
        }

        /// <summary>
        /// Determines the player with the most votes and returns them.
        /// </summary>
        /// <returns></returns>
        public Player GetEliminatedPlayerId() 
        {
            var eliminatedPlayer = HaveVoted.Values.OrderBy(x => x.Votes).First();
            eliminatedPlayer.IsDead();
            return eliminatedPlayer;
        } 
    }
}
