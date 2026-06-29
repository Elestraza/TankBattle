using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    class Team
    {
        public string Name { get; set; }
        public List<Tank> Tanks { get; set; } = new();

        public bool IsDefeated => Tanks.All(t => !t.IsAlive);
    }
}
