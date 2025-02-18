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
    public class UtilsTests
    {
        public List<Player> PlayerList { get; set; } = new List<Player>();

        [TestMethod]
        public void Should_Shuffle_List() 
        {
           //Arrange


            Utils utils = new Utils();
            Mafia player1 = new Mafia("John", 1, Domain.Core.Logic.Enum.RoleType.Mafia);
            Citizen player2 = new Citizen("Maria", 2, Domain.Core.Logic.Enum.RoleType.Citizen);
            Detective player3 = new Detective("Monk", 3, Domain.Core.Logic.Enum.RoleType.Detective);

            PlayerList.Add(player1);
            PlayerList.Add(player2);
            PlayerList.Add(player3);

            //Act

            var shuffledList = utils.ShuffleList(PlayerList);

            //Assert

            Assert.AreEqual(PlayerList.Count, 3);
            Assert.AreNotSame(shuffledList, PlayerList);
        }
    }
}
