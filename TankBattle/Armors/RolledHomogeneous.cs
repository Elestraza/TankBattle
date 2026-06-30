using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Armors
{
    class RolledHomogeneous : Armor // Катаная гомогенная броня
    {
        public RolledHomogeneous()
        {
            Protection = 0.20f;
        }
        public override Int32 ReduceDamage(Int32 damage, Ammo ammo)
        {
            return (Int32)(damage * (1f - Protection));
        }
    }
}
