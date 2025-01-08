using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Palermo.Domain.Core.Logic.Interfaces
{
    internal interface IRole
    {

        /// <summary>
        /// Executes a role-specific action during the Night phase.
        /// </summary>
        /// <param name="game"></param>
        void PerformNightAction(Game game) 
        {
        
        }
    }
}
