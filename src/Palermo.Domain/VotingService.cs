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
    public class VotingService
    {        
        

       /// <summary>
       /// Maps the voter's id to the voter.
       /// </summary>
        private Dictionary<int, Player> _haveVoted { get; set; } = new Dictionary<int, Player>();
        public List<Player> Players { get; set; } 

        public VotingResults VotingResults { get; set; }


        public VotingService(List<Player> players)
        {
            Players = players;
            VotingResults = new VotingResults();
        }

        /// <summary>
        /// Casts another player's vote towards the player of their choosing.
        /// </summary>
        /// <param name="voter"></param>
        /// <param name="target"></param>
        /// <param name="players"></param>
        /// <exception cref="Exception"></exception>

        public void CastVote(Player voter, Player target)
        {           
                voter.Vote(target);
                _haveVoted.Add(voter.Id, voter);
           
        }




        /// <summary>
        /// Resets the number of votes on each player and clears the documents of who voted for whom in the previous round. 
        /// </summary>
        /// <param name="players"></param>
        public void ResetVotingProcess(List<Player> players) 
        {

            _haveVoted.Clear();

            VotingResults.FinalVotes.Clear();

            VotingResults.EliminatedPlayer = null; 

            foreach (Player player in players) 
            {
             player.ResetVotes();
            }

           

        }

        /// <summary>
        /// Determines the player with the most votes and returns them.
        /// </summary>
        /// <returns></returns>
        public Player GetEliminatedPlayer() 
        {
            var eliminatedPlayer = _haveVoted.Values.OrderBy(x => x.Votes).First();
            return eliminatedPlayer;
        } 


        /// <summary>
        /// Eliminates the player with the most votes.
        /// </summary>
        public void EliminatePlayer() 
        {
         var eliminatedPlayer = GetEliminatedPlayer();
         VotingResults.EliminatedPlayer = eliminatedPlayer;
         eliminatedPlayer.EliminatePlayer();
         
        }



        /// <summary>
        /// Displays the results of the voting process, meaning how many votes each player got.
        /// </summary>
        public Dictionary<Player, int> DisplayVotingResults() 
        {
            foreach (Player player in Players) 
            {
                VotingResults.FinalVotes.Add(player, player.Votes);
            }

            return VotingResults.FinalVotes;
        }



        public void EndVotingProcess() 
        {
            DisplayVotingResults();
            EliminatePlayer();
        }

    }
}
