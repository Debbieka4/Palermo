using Palermo.Domain.Core.Logic;
using Palermo.Domain.Core.Logic.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Tests
{
    [TestClass]
    public class VoteTest
    {
        [TestMethod]
        public void Is_Vote_Being_Cast()
        {

           // Arrange 

            Vote vote = new Vote();
            Mafia player1 = new Mafia("John", 1, Domain.Core.Logic.Enum.RoleType.Mafia);
            Citizen player2 = new Citizen("Maria", 2, Domain.Core.Logic.Enum.RoleType.Citizen);
            Detective player3 = new Detective("Monk", 3, Domain.Core.Logic.Enum.RoleType.Detective);

            List<Player> list = new List<Player>();
            list.Add(player1);
            list.Add(player2);
            list.Add(player3);

           // Act

            vote.CastVote(player2, player1, list);
            vote.CastVote(player1, player2, list);
            vote.CastVote(player3, player1, list);

            // Assert

            var eliminatedPlayer = vote.GetEliminatedPlayerId();
            

        }
    }
}
