using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Domain.Core.Logic.Players
{
    internal class Citizen : Player
    {
        public Citizen(string name)
            :base(name) 
        {
            this.Role = Enum.RoleType.Citizen;
        }

        public override void PerformNightAction(Game game)
        {
           
        }
    }
}
