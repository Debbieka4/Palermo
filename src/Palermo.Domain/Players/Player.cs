using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palermo.Domain.Core.Logic.Enum;
using Palermo.Domain.Core.Logic.Interfaces;

namespace Palermo.Domain.Core.Logic.Players
{
    abstract class Player : IRole
    {
        public int Id { get; private set; }
        public string Name { get;  set; }
        public RoleType Role { get;  set; }
        public bool IsAlive { get; private set; }


        public Player(string name)
        {
            Name = name;
        }

        public abstract void PerformNightAction(Game game);
    }


}
