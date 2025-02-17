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


        /// <summary>
        /// Adds a vote to the total votes of the player.
        /// </summary>
        public void AddVote() 
        {
        Votes++;
        }


        /// <summary>
        /// Sets player's total votes to zero.
        /// </summary>
        public void ResetVotes() 
        {
         Votes = 0;
        }



        /// <summary>
        /// Marks a player as dead.
        /// </summary>
        public void EliminatePlayer() 
        {
         IsAlive = false;
        }
       



        /// <summary>
        /// Casts their vote towards the target player.
        /// </summary>
        /// <param name="target"></param>
        /// <exception cref="Exception"></exception>
        public void Vote(Player target) 
        {
         if (target.Id.Equals(Id))
            {
                throw new Exception("Player cannot vote for themselves");
            }
         else if (target.IsAlive == false) 
            {
                throw new Exception("Player cannot vote for a player who has died.");
            }
         else if (IsAlive == false) 
            {
                throw new Exception("Player voter has died, cannot vote.");
            }
         else if (target == null) 
            {
                throw new Exception("Target player is null");
            }


         target.AddVote();
        }

        public abstract void PerformNightAction(Game game);
    }


}
