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
    public class VotingServiceTests
    {

        public List<Player> PlayerList { get; set; }

        [TestMethod]
        public void Is_Eliminating_Right_Player()
        {

            // Arrange 


            VotingService votingService = new VotingService(PlayerList);
            CreatePlayers();


            // Act

            CastVotes(votingService);




            // Assert

            Assert.AreEqual(PlayerList[1], votingService.GetEliminatedPlayer());
            

        }


        [TestMethod]
        public void Is_Player_Eliminated()
        {
            //Arrange

            VotingService votingService = new VotingService(PlayerList);
            CreatePlayers();

            //Act

            CastVotes(votingService);
            votingService.EliminatePlayer();

            //Assert

            Assert.IsFalse(PlayerList[1].IsAlive);

        }


        [TestMethod] 
        public void Should_Throw_Exception_When_Player_Is_Not_Alive() 
        {

            //Arrange

          
            VotingService votingService = new VotingService(PlayerList);
            CreatePlayers();
            PlayerList[0].EliminatePlayer();

            //Act


            votingService.CastVote(PlayerList[0], PlayerList[1]);
            votingService.CastVote(PlayerList[1], PlayerList[2]);
            votingService.CastVote(PlayerList[2], PlayerList[1]);


            //Assert


            var ex = Assert.ThrowsException<Exception>(() => votingService.CastVote(PlayerList[0], PlayerList[1]));

            ex.Message.Equals("Player voter has died, cannot vote.");

        }

        [TestMethod]
        public void Should_Throw_Exception_When_Player_Voting_Themselves() 
        {
            //Arrange

            VotingService votingService = new VotingService(PlayerList);

            CreatePlayers();

            //Act 

            votingService.CastVote(PlayerList[0], PlayerList[0]);
            votingService.CastVote(PlayerList[1], PlayerList[2]);
            votingService.CastVote(PlayerList[2], PlayerList[1]);

            //Assert

            var ex = Assert.ThrowsException<Exception>(() => votingService.CastVote(PlayerList[0], PlayerList[0]));
            ex.Message.Equals("Player cannot vote for themselves");


        }

        [TestMethod]
        public void Should_Reset_Votes() 
        {

            //Arrange

            VotingService votingService = new VotingService(PlayerList);
            CreatePlayers();

            //Act

            CastVotes(votingService);
            votingService.ResetVotingProcess(PlayerList);

            //Assert

            foreach (var player in PlayerList) 
            {
                Assert.Equals(player.Votes, 0);
            }

        }


        public void CreatePlayers()
        {
      
            Mafia player1 = new Mafia("John", 1, Domain.Core.Logic.Enum.RoleType.Mafia);
            Citizen player2 = new Citizen("Maria", 2, Domain.Core.Logic.Enum.RoleType.Citizen);
            Detective player3 = new Detective("Monk", 3, Domain.Core.Logic.Enum.RoleType.Detective);
        
            PlayerList.Add(player1);
            PlayerList.Add(player2);
            PlayerList.Add(player3);
            

         
          

        }


        public void CastVotes(VotingService votingService) 
        {
            votingService.CastVote(PlayerList[0], PlayerList[1]);
            votingService.CastVote(PlayerList[1], PlayerList[2]);
            votingService.CastVote(PlayerList[2], PlayerList[1]);
        }
    }
}
