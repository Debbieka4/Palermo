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

        



        public void CastVote(Player voter, Player target, List<Player> players) 
        {
          
                if (!HaveVoted.ContainsKey(voter))
                {
                   if (voter.IsVotingThemselves(voter))
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
