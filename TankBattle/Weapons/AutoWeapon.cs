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

        public override Double Shoot(Tank attacker, Double Accuracy)
        {
            if (attacker.Ammunition.Count == 0)
            {
                Console.WriteLine($"{attacker.Name}: нет снарядов для стрельбы!");
                return 0;
            }

            Double fullDamage = 0;
            Int32 shotsFired = 0;
            for (Int32 i = 0; i < 2; i++)
            {
                if (attacker.Ammunition.Count == 0)
                {
                    Console.WriteLine($"{attacker.Name}: нет снарядов для стрельбы!");
                    break;
                }

                Ammo currentAmmo = attacker.Ammunition.First();

                if (!CanUse(currentAmmo))
                {
                    Console.WriteLine($"{attacker.Name} - Осечка! Снаряд не подходит!");
                    attacker.Ammunition.RemoveAt(0);
                    attacker.Weight -= currentAmmo.AmmoWeight;
                    continue;
                }

                if (Random.Shared.NextDouble() < Accuracy)
                {
                    fullDamage += Random.Shared.Next(10, 16) + currentAmmo.Damage;
                    Console.WriteLine($"{attacker.Name}: Выстрел {i + 1} попал!");
                } else
                {
                    Console.WriteLine($"{attacker.Name}: Выстрел {i + 1} промазал.");
                }

                attacker.Ammunition.RemoveAt(0);
                attacker.Weight -= currentAmmo.AmmoWeight;
                shotsFired++;
            }

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
