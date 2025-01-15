﻿using Palermo.Domain.Core.Logic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palermo.Domain.Core.Logic.Players
{
    internal class Mafia : Player
    {
        public Mafia(string name)
            :base(name) 
        {
            this.Role = RoleType.Mafia;
        }

        public override void PerformNightAction(Game game)
        {
            game.ExecuteNightPhase();
        }

    }
}
