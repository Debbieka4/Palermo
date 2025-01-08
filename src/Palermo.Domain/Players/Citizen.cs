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
            
        }

        public override void PerformNightAction(Game game)
        {
           
        }
    }
}
