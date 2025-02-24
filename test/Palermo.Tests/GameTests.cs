using Palermo.Domain.Core.Logic;
using Palermo.Domain.Core.Logic.Enum;

namespace Palermo.Tests
{
    [TestClass]
    public class GameTests
    {

        [TestMethod]
        public void Should_Initialize_Game() 
        {
            //Arrange           

            var playerNames = new List<string>()
            {
             "John",
             "Maria",
             "Melissandre",
             "Daenerys"
            };
            
            int numberOfPlayers = playerNames.Count;

            Game game = new Game(6, numberOfPlayers);

            //Act

            game.InitializeGame(playerNames);

            //Assert

            var mafiaPlayers = game.Players.Where(p => p.Role == RoleType.Mafia).ToList();

            var detective = game.Players.Where(p => p.Role == RoleType.Detective).ToList();

            var citizenPlayers = game.Players.Where(p => p.Role == RoleType.Citizen).ToList();

            Assert.AreEqual(numberOfPlayers, game.Players.Count);
            Assert.AreEqual(mafiaPlayers.Count, 2);
            Assert.AreEqual(detective.Count, 1);
            Assert.AreEqual(citizenPlayers.Count, 1);
        }


        [TestMethod]
        public void Should_Throw_Exception_When_Player_Count_Is_Below_Three() 
        {
            //Assert

            var playerNames = new List<string>()
            {
             "John",
             "Maria",
             "Melissandre",
            };

            int numberOfPlayers = playerNames.Count;

            Game game = new Game(6, numberOfPlayers);

            //Act

            game.InitializeGame(playerNames);

            //Assert
            var ex = Assert.ThrowsException<Exception>(() => game.InitializeGame(playerNames));

            ex.Message.Equals("Number of players must be over 3.");

        }


       



    }
}
