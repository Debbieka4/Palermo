using Palermo.Domain.Core.Logic;
using Palermo.Domain.Core.Logic.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Tests
{
    public class GameTests
    {

        [TestMethod]
        public void Should_Initialize_Game() 
        {
            //Arrange
            Game game = new Game(6, 4);

            var playerNames = new List<string>()
            {
             "John",
             "Maria",
             "Melissandre",
             "Daenerys"
            };
            
            int numberOfPlayers = playerNames.Count;

            //Act

            game.InitializeGame(playerNames);

            //Assert

            var mafiaPlayers = game.Players.GroupBy(p => p.Role == Domain.Core.Logic.Enum.RoleType.Mafia).ToList();

            var detective = game.Players.GroupBy(p => p.Role == Domain.Core.Logic.Enum.RoleType.Detective).ToList();

            var citizenPlayers = game.Players.GroupBy(p => p.Role == Domain.Core.Logic.Enum.RoleType.Citizen).ToList();

            Assert.AreEqual(numberOfPlayers, game.Players.Count);
            Assert.AreEqual(mafiaPlayers.Count, 2);
            Assert.AreEqual(detective.Count, 1);
            Assert.AreEqual(citizenPlayers.Count, 1);
        }


       



    }
}
