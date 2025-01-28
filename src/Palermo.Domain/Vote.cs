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
    internal class Vote
    {        
        

       /// <summary>
       /// Maps the voter's id to the id of the player they are voting.
       /// Key: voter id, Value: target player id.
       /// </summary>
        public Dictionary<int, int> Votes { get; set; }

        /// <summary>
        /// Matches the target player's id with the number of total votes
        /// they have received from other players.
        /// </summary>
        public Dictionary<int, int> Player { get; set; }

     

        public Vote(Dictionary<int, int> votes)
        {
            this.Votes = votes;
        }


        /// <summary>
        /// Handles the voting process and finally returns the eliminated player's name.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
      
        public string VotingProcess(List<Player> players)
        {
            string eliminatedPlayer = string.Empty;     

            if (Votes.Count == players.Count)
            {
                DetermineNumberOfVotes();
                var eliminatedPlayerId = GetEliminatedPlayerId();


                foreach (var player in players)
                {
                    if (player.Id == eliminatedPlayerId) 
                    {
                     eliminatedPlayer = player.Name;
                    }
            }
            }
            else
            {
                throw new Exception("Not all players have voted.");
            }


            return eliminatedPlayer;

        }


        /// <summary>
        /// Determines how many votes in total a player has received from other players.
        /// </summary>
        public void DetermineNumberOfVotes() 
        {
            var byTargetId = Votes.GroupBy(v => v.Value);                   

            foreach (var groupItem in byTargetId)
            {
                var totalVotes = groupItem.Count();
                Player.Add(groupItem.Key, totalVotes);
                
            }
         
        }

        /// <summary>
        /// Determines the player with the most votes and returns their id.
        /// </summary>
        /// <returns></returns>
        public int GetEliminatedPlayerId() 
        {
            var playerWithMaxVote = Player.Max();          
            return playerWithMaxVote.Key; 
        } 
    }
}
