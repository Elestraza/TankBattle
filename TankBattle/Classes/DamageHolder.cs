using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    class DamageHolder
    {
        public Tank Attacker { get; set; }
        public Tank Reciever { get; set; }
        public Int32 RecievingDamage { get; set; }
        public Ammo AttackerAmmo { get; set; }
    }
}
