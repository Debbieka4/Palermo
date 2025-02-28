using Palermo.Domain.Core.Logic;
using Palermo.Domain.Core.Logic.Enum;
using Palermo.Domain.Core.Logic.Players;

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


        [TestMethod]
        public void Should_Generate_Player_Ids() 
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

            var ids =  game.GeneratePlayerId(numberOfPlayers);

            //Assert

            var correctIds = new List<int>()
            {
             0,
             1,
             2,
             3
            };
            Assert.IsTrue(ids.Any());
            Assert.AreEqual(numberOfPlayers, ids.Count);
            Assert.AreEqual(ids, correctIds);
            
        }




        [TestMethod]
        public void Should_Check_Victory_Conditions()
        {
            //Arrange           
            var playerList = new List<Player>();

            Mafia player0 = new Mafia("Ser Davos", 0, RoleType.Mafia);
            Mafia player1 = new Mafia("John", 1, RoleType.Mafia);
            Citizen player2 = new Citizen("Maria", 2, RoleType.Citizen);
            Detective player3 = new Detective("Monk", 3, RoleType.Detective);
            player3.EliminatePlayer();


            playerList.Add(player0);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);


            Game game = new Game(6, playerList.Count);

            //Act

            var hasGameEnded = game.CheckVictoryConditions();

            //Assert

            Assert.IsTrue(hasGameEnded);
           
        }


        [TestMethod]
        public void Should_Reveal_Roles() 
        {
            //Arrange


            Game game = new Game(6, 4);

            var playerList = new List<Player>();

            Mafia player0 = new Mafia("Ser Davos", 0, RoleType.Mafia);
            Mafia player1 = new Mafia("John", 1, RoleType.Mafia);
            Citizen player2 = new Citizen("Maria", 2, RoleType.Citizen);
            Detective player3 = new Detective("Monk", 3, RoleType.Detective);
            

            game.Players.Add(player0);
            game.Players.Add(player1);
            game.Players.Add(player2);
            game.Players.Add(player3);


            //Act

            var playersWithRoles = game.RevealRoles();

            //
            Assert.AreEqual(playersWithRoles.Keys.ToList(), game.Players.Select(p => p.Name).ToList());
            Assert.AreEqual(playersWithRoles.Values.ToList(), game.Players.Select(p => p.Role.ToString()).ToList());


        }



    }
}
