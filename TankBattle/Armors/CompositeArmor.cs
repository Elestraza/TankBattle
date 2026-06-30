
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

        public override Int32 ReduceDamage(Int32 damage, Ammo ammo)
        {
            if (ammo is Cumulative)
            {
                damage = (Int32)(damage * 0.6f);
            }
            return (Int32)(damage * (1f - Protection));
        }
    }
}
