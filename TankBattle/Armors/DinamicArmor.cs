
using TankBattle.Ammunitions;
using TankBattle.Classes;

namespace TankBattle.Armors
{
    class DinamicArmor : Armor 
    {
        public DinamicArmor()
        {
            Protection = 0.20f;
        }

        public override Int32 ReduceDamage(Int32 damage, Ammo ammo)
        {
            if (ammo is not ArmorPearcing)
            {
                return (Int32)(damage * 0.8f);
            }
            if (ammo is Cumulative) // Если Комулятивный снаряд
            {
                if (Random.Shared.NextDouble() < 0.6f) // 60% шанс отразить
                {
                    return 0;
                }
            }
            return damage; // Полный урон, если Бронебойный снаряд
        }
    }
}
