using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Ammunitions
{
    class HighExplosive : Ammo // Осколосно-фугасный
    {
        public HighExplosive()
        {
            Damage = 5;
            AmmoWeight = 250;
        }
    }
}
