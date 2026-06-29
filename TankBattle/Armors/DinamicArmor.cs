
using TankBattle.Ammunitions;
using TankBattle.Classes;

namespace TankBattle.Armors
{
    class DinamicArmor : Armor 
    {
        public DinamicArmor()
        {
            Protection = 0.20;
        }

        public override int ReduceDamage(int damage, Ammo ammo)
        {
            if (ammo is AP)
                return damage;

            if (ammo is AP)
            {
                if (Random.Shared.NextDouble() < 0.6)
                    return 0;
            }

            return (int)(damage * 0.8);
        }
    }
}
