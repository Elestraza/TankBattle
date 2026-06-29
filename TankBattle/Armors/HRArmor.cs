using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Armors
{
    class HRArmor : Armor // Катаная гомогенная броня
    {
        public HRArmor()
        {
            Protection = 0.20f;
        }
        public override int ReduceDamage(int damage, Ammo ammo)
        {
            return (int)(damage * (1f - Protection));
        }
    }
}
