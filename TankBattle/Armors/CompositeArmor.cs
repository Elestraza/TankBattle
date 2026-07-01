
using TankBattle.Ammunitions;
using TankBattle.Classes;

namespace TankBattle.Armors
{
    class CompositeArmor : Armor 
    {
        public CompositeArmor()
        {
            Protection = 0.15f;
        }

        public override Double ReduceDamage(Double damage, Ammo ammo)
        {
            if (ammo is Cumulative)
            {
                damage = damage * 0.6f;
            }
            return (damage * (1f - Protection));
        }
    }
}
