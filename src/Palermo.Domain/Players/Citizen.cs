using Palermo.Domain.Core.Logic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Domain.Core.Logic.Players
{
    public class Citizen : Player
    {
        public Citizen(string name, int id, RoleType role)
            :base(name, id, role) 
        {
        
        }

        public override void PerformNightAction(Game game)
        {
           
        }
    }
}
