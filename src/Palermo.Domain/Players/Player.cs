using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palermo.Domain.Core.Logic.Enum;
using Palermo.Domain.Core.Logic.Interfaces;

namespace Palermo.Domain.Core.Logic.Players
{
    abstract public class Player : IRole
    {
        public int Id { get; private set; }
        public string Name { get;  private set; }
        public RoleType Role { get;  private set; }
        public bool IsAlive { get; private set; } 

        public int Votes { get; private set; }


        public Player(string name, int id, RoleType role)
        {
            Name = name;
            Id = id;
            Role = role;
            IsAlive = true;
        }


        public void AddVote() 
        {
        Votes++;
        }

        public void ResetVotes() 
        {
         Votes = 0;
        }

        public void EliminatePlayer() 
        {
         IsAlive = false;
        }

        public bool IsVotingThemselves(Player target) 
        {
            var equal = target.Id.Equals(Id);
            return equal;
        }

        public abstract void PerformNightAction(Game game);
    }


}
