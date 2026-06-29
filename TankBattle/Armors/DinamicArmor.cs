
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

        public override int ReduceDamage(int damage, Ammo ammo)
        {
            if (ammo is not AP)
            {
                return (int)(damage * 0.8f);
            }
            if (ammo is SC) // Если Комулятивный снаряд
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
