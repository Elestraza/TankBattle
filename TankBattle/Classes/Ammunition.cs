using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    abstract class Ammo
    {
        public Int32 Damage { get; protected set; }
        public Int32 AmmoWeight { get; protected set; }
    }
}
