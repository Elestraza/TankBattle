
using TankBattle.Ammunitions;
using TankBattle.Classes;

namespace TankBattle.Armors
{
    class CompositeArmor : Armor 
    {
        public CompositeArmor()
        {
            Protection = 0.15;
        }

        public override int ReduceDamage(int damage, Ammo ammo)
        {
            if (ammo is SC)
                damage = (int)(damage * 0.6);

            return (int)(damage * (1 - Protection));
        }
    }
}
