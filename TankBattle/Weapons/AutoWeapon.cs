using TankBattle.Ammunitions;
using TankBattle.Classes;

namespace TankBattle.Weapons
{
    class AutoWeapon : Weapon // Автоматическое оружие
    {
        public AutoWeapon()
        {
            Accuracy = -0.15f;
        }

        public override (int, Double) Shoot(Tank tank, Ammo ammo, Double Accuracy)
        {
            Int32 damage = 0;

            for (Int32 i = 0; i < 3; i++)
            {
                if (Random.Shared.NextDouble() < Accuracy)    
                {
                    damage += Random.Shared.Next(10, 16);
                }
                else
                {
                    Console.WriteLine("Выстрел " + i + " промазал.");
                }
            }
            return ((damage + ammo.Damage), Accuracy);
        }

        public override bool CanUse(Ammo ammo)
        {
            return ammo is HighExplosive || ammo is ArmorPearcing;
        }

    }
}
