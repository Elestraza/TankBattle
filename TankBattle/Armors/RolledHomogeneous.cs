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
        public override Double ReduceDamage(Double damage, Ammo ammo)
        {
            return (Double)(damage * (1f - Protection));
        }
    }
}
