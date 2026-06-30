using TankBattle.Ammunitions;
using TankBattle.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Weapons
{
    class AutoWeapon : Weapon // Автоматическое оружие
    {
        public AutoWeapon()
        {
            Accuracy = -0.15f;
            ReloadTime = 1;
        }

        public override int Shoot(Ammo ammo, Double Accuracy)
        {
            if (!CanUse(ammo))
            {
                return 0;
            }
            if (ReloadTime > 0)
            {
                ReloadTime = 0;
                return 0;
            }
            Int32 damage = 0;

            for (Int32 i = 0; i < 3; i++)
            {
                if (Random.Shared.NextDouble() < Accuracy)
                {
                    damage += Random.Shared.Next(10, 16);
                } else
                {
                    Console.WriteLine("Выстрел " + i + " промазал.");
                }
            }
            ReloadTime = 1;
            return (damage + ammo.Damage);

        }

        public override bool CanUse(Ammo ammo)
        {
            return ammo is HighExplosive || ammo is ArmorPearcing;
        }

    }
}
