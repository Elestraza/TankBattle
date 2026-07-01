using TankBattle.Ammunitions;
using TankBattle.Classes;

namespace TankBattle.Weapons
{
    class AutoWeapon : Weapon // Автоматическое оружие
    {
        public override Double Accuracy => base.Accuracy - (base.Accuracy * 0.15f);
        public AutoWeapon()
        {
            ReloadTime = 1;
        }

        public override int Shoot(Tank attacker, double Accuracy)
        {
            if (attacker.Ammunition.Count == 0)
            {
                Console.WriteLine($"{attacker.Name}: нет снарядов для стрельбы!");
                return 0;
            }

            Ammo currentAmmo = attacker.Ammunition.First();

            if (!CanUse(currentAmmo))
            {
                Console.WriteLine($"{attacker.Name} - Осечка! Снаряд {currentAmmo.GetType().Name} не подходит.");
                attacker.Ammunition.RemoveAt(0);
                attacker.Weight -= currentAmmo.AmmoWeight;
                return 0;
            }

            if (ReloadTime > 0)
            {
                Console.WriteLine($"{attacker.Name} - Перезарядка");
                ReloadTime = 0;
                return 0;
            }

            int fullDamage = 0;
            for (int i = 0; i < 2; i++)
            {
                if (Random.Shared.NextDouble() < Accuracy)
                {
                    fullDamage += Random.Shared.Next(10, 16) + currentAmmo.Damage;
                } else
                {
                    Console.WriteLine($"{attacker.Name}: Выстрел {i + 1} промазал.");
                }
            }

            attacker.Ammunition.RemoveAt(0);
            attacker.Weight -= currentAmmo.AmmoWeight;
            ReloadTime = 1;
            return fullDamage;
        }

        public override bool CanUse(Ammo ammo)
        {
            if (ammo is HighExplosive)
                return true;
            if (ammo is ArmorPearcing)
                return true;
            return false;
        }
    }
}
