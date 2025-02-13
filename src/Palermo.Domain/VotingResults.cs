using Palermo.Domain.Core.Logic;
using Palermo.Domain.Core.Logic.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Domain
{
    public class VotingResults
    {
        public Player EliminatedPlayer { get; set; } 
        public Dictionary<Player,int> FinalVotes { get; set; }


        public VotingResults()
        {
            FinalVotes = new Dictionary<Player,int>();
        }

    }
}
